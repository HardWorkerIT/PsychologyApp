using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace PsychologyApp.Presentation.Shared.Common;

/// <summary>An <see cref="ObservableCollection{T}"/> that can take many items with a single change notification, so the UI lays out once instead of once per item.</summary>
public sealed class RangeObservableCollection<T> : ObservableCollection<T>
{
    public void AddRange(IReadOnlyCollection<T> items)
    {
        if (items.Count == 0)
        {
            return;
        }

        foreach (T item in items)
        {
            Items.Add(item);
        }

        OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(Count)));
        OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Item[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public void InsertRange(int index, IReadOnlyCollection<T> items)
    {
        InsertRangeCore(index, items, replacementIndex: null, replacement: default);
    }

    /// <summary>Inserts a range, replaces one resulting item, and emits a single Reset for the whole update.</summary>
    public void InsertRangeAndReplace(int index, IReadOnlyCollection<T> items, int replacementIndex, T replacement)
    {
        InsertRangeCore(index, items, replacementIndex, replacement);
    }

    private void InsertRangeCore(int index, IReadOnlyCollection<T> items, int? replacementIndex, T? replacement)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        if (index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (replacementIndex is { } replaceAt
            && (items.Count == 0 || replaceAt < index + items.Count || replaceAt >= Count + items.Count))
        {
            throw new ArgumentOutOfRangeException(nameof(replacementIndex));
        }

        if (items.Count == 0)
        {
            return;
        }

        int insertionIndex = index;
        foreach (T item in items)
        {
            Items.Insert(insertionIndex++, item);
        }

        if (replacementIndex is { } replaceIndex)
        {
            Items[replaceIndex] = replacement!;
        }

        OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(Count)));
        OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Item[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    /// <summary>Swaps the whole contents with one Reset, instead of a Clear plus one Add notification per item.</summary>
    public void ReplaceAll(IEnumerable<T> items)
    {
        Items.Clear();
        foreach (T item in items)
        {
            Items.Add(item);
        }

        OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(Count)));
        OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Item[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}
