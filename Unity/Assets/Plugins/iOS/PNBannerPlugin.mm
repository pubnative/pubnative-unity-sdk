#import "PNBannerWrapper.h"
#import "PNAdPool.h"

@interface PNBannerPlugin : NSObject

+ (void)loadBannerWithObject:(NSString*)objectName
                withAppToken:(NSString*)appToken
               withPlacement:(NSString*)placement
                withBannerID:(NSString *)bannerID;

+ (void)showBannerWithID:(NSString *)bannerID
            withPosition:(NSInteger)position;

+ (void)hideBannerWithID:(NSString *)bannerID;

+ (void)removeBannerFromPoolWithID:(NSString *)bannerID;

@end

static PNBannerPlugin *_sharedInstance;

@implementation PNBannerPlugin

+ (PNBannerPlugin*)sharedInstance
{
    if(_sharedInstance == nil)
    {
        _sharedInstance = [[PNBannerPlugin alloc] init];
    }
    return _sharedInstance;
}

+ (void)loadBannerWithObject:(NSString *)objectName
                withAppToken:(NSString *)appToken
               withPlacement:(NSString *)placement
                withBannerID:(NSString *)bannerID
{
    PNBannerWrapper* bannerWrapper = [[PNBannerWrapper alloc] init];
    bannerWrapper.adID = bannerID;
    [[PNAdPool sharedPool].bannerPool setObject:bannerWrapper forKey:bannerWrapper.adID];
    [bannerWrapper loadWithObject:objectName withAppToken:appToken withPlacement:placement];
}

+ (void)showBannerWithID:(NSString *)bannerID
            withPosition:(NSInteger)position
{
    PNBannerWrapper* bannerWrapper = [[PNAdPool sharedPool].bannerPool objectForKey:bannerID];
    if (bannerWrapper) {
        [bannerWrapper showWithPosition:position];
    }
}

+ (void)hideBannerWithID:(NSString *)bannerID
{
    PNBannerWrapper* bannerWrapper = [[PNAdPool sharedPool].bannerPool objectForKey:bannerID];
    if (bannerWrapper) {
        [bannerWrapper hide];
    }
}

+ (void)removeBannerFromPoolWithID:(NSString *)bannerID
{
    [[PNAdPool sharedPool].bannerPool removeObjectForKey:bannerID];
}

@end

#ifdef __cplusplus
extern "C"
{
    void loadBanner(const char* obj, const char* appToken, const char* placement, const char* bannerID)
    {
        [PNBannerPlugin loadBannerWithObject:[NSString stringWithUTF8String:obj]
                                withAppToken:[NSString stringWithUTF8String:appToken]
                               withPlacement:[NSString stringWithUTF8String:placement]
                                withBannerID:[NSString stringWithUTF8String:bannerID]];
    }
    
     void showBanner(const char* bannerID, int positon)
    {
        [PNBannerPlugin showBannerWithID:[NSString stringWithUTF8String:bannerID]
                            withPosition:(NSInteger)positon];
    }
    
    void hideBanner(const char* bannerID)
    {
        [PNBannerPlugin hideBannerWithID:[NSString stringWithUTF8String:bannerID]];
    }
    
    void removeBanner(const char* bannerID)
    {
        [PNBannerPlugin removeBannerFromPoolWithID:[NSString stringWithUTF8String:bannerID]];
    }
}
#endif
