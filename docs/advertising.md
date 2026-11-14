# Advertising integration

The Android app loads VK Ads banners automatically in eligible practice, course, article, and general quotes catalogs. The quote banner is limited to the non-personal All feed. The official [myTarget Android SDK repository](https://github.com/myTargetSDK/mytarget-android) identifies the SDK as `com.my.target:mytarget-sdk`; the project currently pins version 5.52.5.

The public [privacy policy](https://hardworkerit.github.io/PsychologyApp/privacy-policy/) and an HTTPS policy URL are required before an ad view can be created. Banners load automatically in eligible catalogs; no in-app consent prompt is shown. The ad-free EISBRECHER preference disables ad views and requests.

- `AdvertisingConfiguration.PrivacyPolicyUrl` points to the public HTTPS policy.
- `AdvertisingConfiguration.VkReadingCatalogBannerSlotId` is set to the registered banner block `2107995`.
- Ad requests are gated by the valid policy URL, positive slot ID, Android placement eligibility, and the ad-free preference.
- The SDK receives `false` through myTarget's user-consent API. The app does not obtain or signal affirmative user consent; do not treat this flag as proof of a legally valid consent flow.

The earlier Yandex block ID R-M-20382360-1 belongs to Yandex and cannot be used with VK Ads.

## Integration requirements

- Use the high-traffic Practice tab as the primary placement: one inline banner after the practice-catalog heading, only after the dashboard risk check completes and when it has no clinical-risk notice. Place a single banner in the course catalog after the third course, in the article catalog after the sixth article, and in the general quotes feed after the eighth quote. Keep no more than one banner visible on a page; hide the article banner during search and for empty results, and hide the quote banner in For you, Favorites, search, and empty results.
- Do not place ads in chat, journal, body check, tests, results, crisis, safety-plan, personalized recommendations, or help screens. Do not add full-screen, app-open, or rewarded ads in this rollout.
- The current VK slot ID is shared among all placements, so VK statistics and frequency caps apply to the combined traffic. Create separate slot IDs if placement-level reporting is needed.
- Match the SDK's fixed `320x50` size to the registered block and disable automatic 60-second banner rotation.
- Before a production release, update applicable store data disclosures and verify the disclosure against VK's current SDK disclosures.
- Check the policy URL, VK slot ID, and ad-free preference before creating the ad view. Destroy the view when leaving the page.
- Do not send personal text, health data, chat messages, journal entries, practice answers, or test results to VK or use them for ad targeting.
- Before production rollout, verify SDK network activity and automatic banner presentation on a test device. This device check has not been done yet.

The EISBRECHER code is stored only as a local `AdsDisabled` preference; the code itself is not stored. It is a convenience switch, not a secret or tamper-resistant entitlement. Preference changes retain this flag, and deleting app settings clears it.
