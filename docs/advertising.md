# Future advertising

The app does not contain an advertising SDK and does not load or display ads. Settings can record `AdsDisabled` locally after a valid code is entered; the code itself is not stored. Preference changes retain this flag, and deletion of app settings clears it.

Any future integration must check `IUserPreferencesStore.Load().AdsDisabled` before initializing, requesting or displaying advertisements, and stop an existing ad when the preference changes. Test those behaviours with the chosen SDK. Review its privacy and consent behaviour against `docs/threat-model.md`; never send personal text or health data to an ad provider. The local code is a convenience switch, not a secret or a tamper-resistant entitlement.
