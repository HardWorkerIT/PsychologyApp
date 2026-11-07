using System.ComponentModel;
using System.Runtime.CompilerServices;
using PsychologyApp.Presentation.Common;

namespace PsychologyApp.Presentation.Entities.Journal;

public sealed class JournalDayChip : INotifyPropertyChanged
{
    private bool _isSelected;

    public DateOnly Date { get; init; }
    public string DayLabel { get; init; } = string.Empty;
    public string DayNumber { get; init; } = string.Empty;
    public int? MoodLevel { get; init; }
    public bool HasEntry { get; init; }
    public string AccessibilityDescription =>
        AppStrings.JournalCalendarDayAccessibility(Date, MoodLevel, IsSelected);

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected == value)
            {
                return;
            }

            _isSelected = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(AccessibilityDescription));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
