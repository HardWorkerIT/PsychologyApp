# Advertising integration

The app is prepared for VK Ads banners in the Android practice, course, article, and general quotes catalogs. The quote banner is limited to the non-personal All feed. The official [myTarget Android SDK repository](https://github.com/myTargetSDK/mytarget-android) identifies the SDK as `com.my.target:mytarget-sdk`; the project currently pins version 5.52.5.

Advertising remains opt-in. The public [privacy policy](https://hardworkerit.github.io/PsychologyApp/privacy-policy/) is now configured. The choice is offered inline at the first eligible placement in the practice catalog, with a direct link to the policy; accepting it enables the existing catalog placements, and declining hides the prompt for the current app session. The consent can also be changed in Settings.

- `AdvertisingConfiguration.PrivacyPolicyUrl` points to the public HTTPS policy.
- `AdvertisingConfiguration.VkReadingCatalogBannerSlotId` is set to the registered banner block `2107995`.
- Consent defaults to off. A person can opt in only after the public policy URL is configured and the inline disclosure is shown.
- The ad-free EISBRECHER preference always overrides consent.

Without explicit consent, or while EISBRECHER has disabled ads, none of the banner placements create a VK ad view or request an ad. The earlier Yandex block ID `R-M-20382360-1` belongs to Yandex and cannot be used with VK Ads.

## Integration requirements

- Use the high-traffic Practice tab as the primary placement: one inline banner after the practice-catalog heading, only after the dashboard risk check completes and when it has no clinical-risk notice. Keep secondary banners at the end of the courses and articles catalogs, with no more than one visible on a page; hide the article banner during search and for empty results. Add one banner at the end of the general quotes feed only; hide it in For you, Favorites, search, and empty results.
- Do not place ads in chat, journal, body check, tests, results, crisis, safety-plan, personalized recommendations, or help screens. Do not add full-screen, app-open, or rewarded ads in this rollout.
- The current VK slot ID is shared among all placements, so VK statistics and frequency caps apply to the combined traffic. Create separate slot IDs if placement-level reporting is needed.
- Match the SDK's fixed `320x50` size to the registered block and disable automatic 60-second banner rotation.
- Before a production release, update applicable store data disclosures and verify the consent text against VK's current SDK disclosures.
- Check the policy URL, VK slot ID, consent, and ad-free preference before creating the ad view. Destroy the view when leaving the page or withdrawing consent.
- Do not send personal text, health data, chat messages, journal entries, practice answers, or test results to VK or use them for ad targeting.
- Before production rollout, verify SDK network activity and banner presentation with explicit consent on a test device. This device check has not been done yet.

The EISBRECHER code is stored only as a local `AdsDisabled` preference; the code itself is not stored. It is a convenience switch, not a secret or tamper-resistant entitlement. Preference changes retain this flag, and deleting app settings clears it.
