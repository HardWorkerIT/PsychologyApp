using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Pages.ClinicalCare.SafetyPlan;

public sealed class SafetyPlanTextItem
{
    public required string Text { get; init; }
    public required ICommand DeleteCommand { get; init; }
    public string RemoveText => AppStrings.Remove;
}

public sealed class SafetyPlanContactItem
{
    public required string Name { get; init; }
    public required string Phone { get; init; }
    public required ICommand CallCommand { get; init; }
    public required ICommand DeleteCommand { get; init; }
    public string CallText => AppStrings.SafetyPlanCallAction;
    public string DeleteText => AppStrings.Remove;
}

public sealed class SafetyPlanViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IClinicalCareService _clinicalCareService;
    private readonly SemaphoreSlim _editGate = new(1, 1);
    private Task? _loadTask;

    public RangeObservableCollection<SafetyPlanTextItem> WarningSigns { get; } = [];
    public RangeObservableCollection<SafetyPlanTextItem> CopingStrategies { get; } = [];
    public RangeObservableCollection<SafetyPlanTextItem> Reasons { get; } = [];
    public RangeObservableCollection<SafetyPlanContactItem> Contacts { get; } = [];

    public string NewWarningSignText { get; set; } = string.Empty;
    public string NewCopingStrategyText { get; set; } = string.Empty;
    public string NewReasonText { get; set; } = string.Empty;
    public string NewContactName { get; set; } = string.Empty;
    public string NewContactPhone { get; set; } = string.Empty;

    public ICommand BackCommand { get; }
    public ICommand AddWarningSignCommand { get; }
    public ICommand AddCopingStrategyCommand { get; }
    public ICommand AddReasonCommand { get; }
    public ICommand AddContactCommand { get; }

    public string PageTitle => AppStrings.SafetyPlanPageTitle;
    public string LeadText => AppStrings.SafetyPlanLead;
    public string WarningSignsTitle => AppStrings.SafetyPlanWarningSignsTitle;
    public string WarningSignsPlaceholder => AppStrings.SafetyPlanWarningSignsPlaceholder;
    public string CopingTitle => AppStrings.SafetyPlanCopingTitle;
    public string CopingPlaceholder => AppStrings.SafetyPlanCopingPlaceholder;
    public string ReasonsTitle => AppStrings.SafetyPlanReasonsTitle;
    public string ReasonsPlaceholder => AppStrings.SafetyPlanReasonsPlaceholder;
    public string ContactsTitle => AppStrings.SafetyPlanContactsTitle;
    public string ContactNamePlaceholder => AppStrings.SafetyPlanContactNamePlaceholder;
    public string ContactPhonePlaceholder => AppStrings.SafetyPlanContactPhonePlaceholder;

    public SafetyPlanViewModel(
        INavigationService navigationService,
        IClinicalCareService clinicalCareService)
    {
        BindNavigation(navigationService);
        _navigationService = navigationService;
        _clinicalCareService = clinicalCareService;

        BackCommand = new AsyncCommand(() => _navigationService.GoBackAsync());
        AddWarningSignCommand = new AsyncCommand(() => AddTextAsync(WarningSigns, () => NewWarningSignText, value => NewWarningSignText = value, nameof(NewWarningSignText)));
        AddCopingStrategyCommand = new AsyncCommand(() => AddTextAsync(CopingStrategies, () => NewCopingStrategyText, value => NewCopingStrategyText = value, nameof(NewCopingStrategyText)));
        AddReasonCommand = new AsyncCommand(() => AddTextAsync(Reasons, () => NewReasonText, value => NewReasonText = value, nameof(NewReasonText)));
        AddContactCommand = new AsyncCommand(AddContactAsync);

        EnsureLoadedAsync().FireAndForget();
    }

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle),
            nameof(LeadText),
            nameof(WarningSignsTitle),
            nameof(WarningSignsPlaceholder),
            nameof(CopingTitle),
            nameof(CopingPlaceholder),
            nameof(ReasonsTitle),
            nameof(ReasonsPlaceholder),
            nameof(ContactsTitle),
            nameof(ContactNamePlaceholder),
            nameof(ContactPhonePlaceholder),
            nameof(AddButtonText));
    }

    private Task EnsureLoadedAsync() =>
        _loadTask is { IsFaulted: false, IsCanceled: false } current ? current : _loadTask = LoadAsync();

    private async Task LoadAsync()
    {
        SafetyPlanDTO plan = await _clinicalCareService.GetSafetyPlanAsync();

        WarningSigns.ReplaceAll(plan.WarningSigns.Select(text => BuildTextItem(WarningSigns, text)).ToList());
        CopingStrategies.ReplaceAll(plan.CopingStrategies.Select(text => BuildTextItem(CopingStrategies, text)).ToList());
        Reasons.ReplaceAll(plan.Reasons.Select(text => BuildTextItem(Reasons, text)).ToList());
        Contacts.ReplaceAll(plan.Contacts.Select(contact => BuildContactItem(contact.Name, contact.Phone)).ToList());
    }

    private SafetyPlanTextItem BuildTextItem(ObservableCollection<SafetyPlanTextItem> collection, string text)
    {
        SafetyPlanTextItem? item = null;
        item = new SafetyPlanTextItem
        {
            Text = text,
            DeleteCommand = new AsyncCommand(() => RemoveTextAsync(collection, item!))
        };
        return item;
    }

    private SafetyPlanContactItem BuildContactItem(string name, string phone)
    {
        SafetyPlanContactItem? item = null;
        item = new SafetyPlanContactItem
        {
            Name = name,
            Phone = phone,
            CallCommand = new AsyncCommand(() => DialAsync(phone)),
            DeleteCommand = new AsyncCommand(() => RemoveContactAsync(item!))
        };
        return item;
    }

    private async Task AddTextAsync(
        ObservableCollection<SafetyPlanTextItem> collection,
        Func<string> getValue,
        Action<string> setValue,
        string propertyName)
    {
        string draft = getValue();
        string text = draft.Trim();
        if (text.Length == 0)
        {
            return;
        }

        await ChangePlanAsync(collection, BuildTextItem(collection, text), add: true);
        if (getValue() == draft)
        {
            setValue(string.Empty);
            OnPropertyChanged(propertyName);
        }
    }

    private Task RemoveTextAsync(ObservableCollection<SafetyPlanTextItem> collection, SafetyPlanTextItem item) =>
        ChangePlanAsync(collection, item, add: false);

    private async Task AddContactAsync()
    {
        string nameDraft = NewContactName;
        string phoneDraft = NewContactPhone;
        string name = nameDraft.Trim();
        string phone = phoneDraft.Trim();
        if (name.Length == 0 && phone.Length == 0)
        {
            return;
        }

        await ChangePlanAsync(Contacts, BuildContactItem(name, phone), add: true);
        if (NewContactName == nameDraft && NewContactPhone == phoneDraft)
        {
            NewContactName = string.Empty;
            NewContactPhone = string.Empty;
            Notify(nameof(NewContactName), nameof(NewContactPhone));
        }
    }

    private Task RemoveContactAsync(SafetyPlanContactItem item) =>
        ChangePlanAsync(Contacts, item, add: false);

    private async Task ChangePlanAsync<TItem>(ObservableCollection<TItem> collection, TItem item, bool add)
    {
        // Each write replaces the whole document. Wait for the initial read and serialize edits across sections.
        await _editGate.WaitAsync();
        try
        {
            await EnsureLoadedAsync();
            int index = add ? collection.Count : collection.IndexOf(item);
            if (index < 0)
            {
                return;
            }

            if (add)
            {
                collection.Add(item);
            }
            else
            {
                collection.RemoveAt(index);
            }

            try
            {
                await PersistAsync();
            }
            catch
            {
                if (add)
                {
                    collection.RemoveAt(index);
                }
                else
                {
                    collection.Insert(index, item);
                }
                throw;
            }
        }
        finally
        {
            _editGate.Release();
        }
    }

    private async Task PersistAsync()
    {
        SafetyPlanDTO plan = new()
        {
            WarningSigns = WarningSigns.Select(item => item.Text).ToArray(),
            CopingStrategies = CopingStrategies.Select(item => item.Text).ToArray(),
            Reasons = Reasons.Select(item => item.Text).ToArray(),
            Contacts = Contacts.Select(item => new SafetyPlanContactDTO { Name = item.Name, Phone = item.Phone }).ToArray()
        };

        await _clinicalCareService.SaveSafetyPlanAsync(plan);
    }

    private static async Task DialAsync(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            return;
        }

        try
        {
            if (PhoneDialer.Default.IsSupported)
            {
                PhoneDialer.Default.Open(number);
                return;
            }

            await Launcher.Default.OpenAsync($"tel:{number}");
        }
        catch (Exception bestEffortError)
        {
            // Best-effort dial.
            BestEffort.Report(bestEffortError);
        }
    }
}
