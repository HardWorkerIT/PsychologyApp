using PsychologyApp.Application.DataBackup;

namespace PsychologyApp.Application.Abstractions.Persistence;

/// <summary>Reads and restores consistent snapshots of the data included in a backup.</summary>
public interface IBackupRepository
{
    Task<AppBackupDTO> ReadExportSnapshotAsync(
        int rowLimit, int escalationLimit, long payloadLimit, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds the backup's rows in one transaction: either all of them or none. A row the database already has (same moment and
    /// content) is skipped, so importing the same file twice changes nothing. Original timestamps are kept, and nothing is
    /// derived from the import moment (no new "completed today" rows).
    /// </summary>
    Task<BackupImportResult> ImportAsync(AppBackupDTO backup, CancellationToken cancellationToken = default);
}
