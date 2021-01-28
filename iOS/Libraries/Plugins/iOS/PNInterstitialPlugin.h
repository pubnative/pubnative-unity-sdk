#include <iostream>

#ifdef __cplusplus
extern "C"
{
    void loadInterstitial(const char* obj, const char* appToken, const char* placement, const char* interstitialID);
    void showInterstitial(const char* interstitialID);
    void hideInterstitial(const char* interstitialID);
    void removeInterstitial(const char* interstitialID);
}
#endif
