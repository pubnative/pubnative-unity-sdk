#include <iostream>

#ifdef __cplusplus
extern "C"
{
    void load(const char* obj, const char* appToken, const char* placement, const char* bannerID);
    void show(const char* bannerID, int positon);
    void hide(const char* bannerID);
    void removeBanner(const char* bannerID);
}
#endif
