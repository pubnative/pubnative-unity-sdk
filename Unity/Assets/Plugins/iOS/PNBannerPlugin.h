#include <iostream>

#ifdef __cplusplus
extern "C"
{
    void loadBanner(const char* obj, const char* appToken, const char* placement, const char* bannerID);
    void showBanner(const char* bannerID, int positon);
    void hideBanner(const char* bannerID);
    void removeBanner(const char* bannerID);
}
#endif
