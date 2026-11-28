using System.ComponentModel;
using PsychologyApp.Presentation.Common;

namespace PsychologyApp.Presentation.Entities.Journal;

public sealed class JournalDayChip : INotifyPropertyChanged
{
    private static readonly PropertyChangedEventArgs SelectionChanged = new(nameof(IsSelected));
    private static readonly PropertyChangedEventArgs DescriptionChanged = new(nameof(AccessibilityDescription));

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
            PropertyChanged?.Invoke(this, SelectionChanged);
            PropertyChanged?.Invoke(this, DescriptionChanged);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}
