# Advertising integration

The Android app uses VK native ads in eligible catalogs, fullscreen ads after eligible articles, and optional rewarded video in settings. The official [myTarget Android SDK repository](https://github.com/myTargetSDK/mytarget-android) identifies the SDK as `com.my.target:mytarget-sdk`; the project currently pins version 5.52.5.

The public [privacy policy](https://hardworkerit.github.io/PsychologyApp/privacy-policy/) and an HTTPS policy URL are required before requesting ads. Native ads load automatically in eligible catalogs. The local ad-free preference disables ad views and requests. A separate, default-off setting controls the SDK's personalized-advertising consent signal and can be changed at any time.

- `AdvertisingConfiguration.PrivacyPolicyUrl` points to the public HTTPS policy.
- `AdvertisingConfiguration.VkCatalogNativeSlotId` is the shared native block (2124987) for practices, articles, courses, and quotes. Its VK statistics combine those placements. Developer packages ending in `.dev` use the SDK demo native slot 6590.
- `AdvertisingConfiguration.VkArticleInterstitialSlotId` is the separate fullscreen block (2124384). Developer packages ending in `.dev` use the SDK demo image slot 6481.
- `AdvertisingConfiguration.VkRewardedSlotId` is the rewarded video block (2124984). Developer packages ending in `.dev` use the SDK demo rewarded slot 45101.
- Ad requests are gated by the valid policy URL, positive slot ID, Android placement eligibility, and the ad-free preference.
- The SDK receives `true` through myTarget's user-consent API only when the person has enabled personalized ads and ads are allowed. Otherwise it receives `false`. The setting is stored locally and updates active placements. With consent enabled, the SDK may collect and send the device advertising ID. Request metadata can still be sent when the setting is off. Review applicable legal and store disclosure requirements before release.

The earlier Yandex block ID R-M-20382360-1 belongs to Yandex and cannot be used with VK Ads.

## Integration requirements

- Show at most one native card on each catalog page. Place it at the end of the practice catalog after the dashboard risk check completes without a clinical-risk notice, after the third course, after the sixth general article, and after the eighth quote in the non-personal All feed. Article search and empty results have no ad. Quote search, For you, Favorites, and empty results also have no ad.
- The placement stays hidden until a native ad is ready. A rejected request leaves the list usable without an empty card. The [SDK binder](https://ads.vk.ru/help/articles/partner_android_native) owns media, AdChoices and impression tracking. The app unregisters the card when the placement is recycled or the page closes. `VkNative` logs requests, loaded cards, impressions and no-ad codes. Verify delivery on the registered release package separately from demo rendering.
- Do not place ads in chat, journal, body check, tests, results, crisis, safety-plan, personalized recommendations, or help screens.
- The fullscreen trial preloads one ad when the user opens an eligible general article about sleep, habits, procrastination, values, or short breaks from the All catalog. It can show after the user reaches the end and uses the reader's Back button to return to that catalog. Search, saved articles, clinical articles, and other entry points are outside the trial. Navigation completes even if the ad is unavailable.
- Fullscreen show attempts are at least ten minutes apart per process. Failed or abandoned loads are discarded. The `VkInterstitial` log records load, display, dismissal, and the SDK's no-ad error code. Verify delivery on the registered release package separately from demo rendering.
- Rewarded video is optional and starts from **Settings → Advertising → Watch video**. Only the SDK's `onReward` event starts a 30-minute pause of ordinary ad requests. The expiry is saved locally and survives restarts. Closing early, leaving during loading, or an unavailable video brings no reward. No app content or personal data is passed as targeting or reward metadata. The `VkRewarded` log records requests, display, dismissal, and confirmed rewards.
- Before a production release, update applicable store data disclosures and verify the disclosure against VK's current SDK disclosures.
- Check the policy URL, VK slot ID, and ad-free preference before creating the ad view. Destroy the view when leaving the page.
- Initialize the SDK on the first eligible ad request, after applying the saved personalization choice. Update the process-wide consent when the preference changes and discard any pending fullscreen ad loaded under a different choice.
- Do not send personal text, health data, chat messages, journal entries, practice answers, or test results to VK or use them for ad targeting.

Applying an invitation code sets a local `AdsDisabled` preference; the code itself is not stored. This is a convenience switch, not a secret or tamper-resistant entitlement. Preference changes retain this flag, and deleting app settings clears it.
