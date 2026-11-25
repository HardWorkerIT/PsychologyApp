namespace PsychologyApp.Presentation.Shared.Common.Infrastructure;

public interface IDatabaseReadySignal
{
    Task WaitAsync(CancellationToken cancellationToken = default);

    void RequestRetry();
}

public sealed class DatabaseReadySignal : IDatabaseReadySignal
{
    private readonly Lock _sync = new();
    private TaskCompletionSource _ready = NewSignal();
    private TaskCompletionSource? _retryRequested;

    public Task WaitAsync(CancellationToken cancellationToken = default)
    {
        lock (_sync)
        {
            return _ready.Task.WaitAsync(cancellationToken);
        }
    }

    public void RequestRetry()
    {
        lock (_sync)
        {
            if (_retryRequested is not { } request)
            {
                return;
            }

            _ready = NewSignal();
            _retryRequested = null;
            request.SetResult();
        }
    }

    internal void SignalReady()
    {
        lock (_sync)
        {
            _ready.SetResult();
        }
    }

    internal Task SignalFailureAndWaitForRetryAsync(Exception exception)
    {
        lock (_sync)
        {
            TaskCompletionSource request = NewSignal();
            _ready.SetException(exception);
            // Startup already reported the failure. A superseded attempt may never have had a reader.
            _ = _ready.Task.Exception;
            _retryRequested = request;
            return request.Task;
        }
    }

    private static TaskCompletionSource NewSignal() => new(TaskCreationOptions.RunContinuationsAsynchronously);
}
