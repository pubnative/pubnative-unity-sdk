#import "HyBidInterstitialWrapper.h"
#import "PNAdPool.h"

@interface PNInterstitialPlugin : NSObject

+ (void)loadInterstitialWithObject:(NSString*)objectName
                      withAppToken:(NSString*)appToken
                     withPlacement:(NSString*)placement
                withInterstitialID:(NSString *)interstitialID;

+ (void)showInterstitialWithID:(NSString *)interstitialID;

+ (void)hideInterstitialWithID:(NSString *)interstitialID;

+ (void)removeInterstitialFromPoolWithID:(NSString *)interstitialID;

@end

static PNInterstitialPlugin *_sharedInstance;

@implementation PNInterstitialPlugin

+ (PNInterstitialPlugin*)sharedInstance
{
    if(_sharedInstance == nil)
    {
        _sharedInstance = [[PNInterstitialPlugin alloc] init];
    }
    return _sharedInstance;
}

+ (void)loadInterstitialWithObject:(NSString *)objectName
                      withAppToken:(NSString *)appToken
                     withPlacement:(NSString *)placement
                withInterstitialID:(NSString *)interstitialID
{
    [[HyBidInterstitialWrapper sharedInstance] loadWithObject:objectName withAppToken:appToken withPlacement:placement withAdId:interstitialID];
}

+ (void)showInterstitialWithID:(NSString *)interstitialID
{
    [[HyBidInterstitialWrapper sharedInstance] show];
}

+ (void)hideInterstitialWithID:(NSString *)interstitialID
{
    [[HyBidInterstitialWrapper sharedInstance] hide];
}

+ (void)removeInterstitialFromPoolWithID:(NSString *)interstitialID
{
    [[PNAdPool sharedPool].interstitialPool removeObjectForKey:interstitialID];
}

@end

#ifdef __cplusplus
extern "C"
{
    void loadInterstitial(const char* obj, const char* appToken, const char* placement, const char* interstitialID)
    {
        [PNInterstitialPlugin loadInterstitialWithObject:[NSString stringWithUTF8String:obj]
                                            withAppToken:[NSString stringWithUTF8String:appToken]
                                           withPlacement:[NSString stringWithUTF8String:placement]
                                      withInterstitialID:[NSString stringWithUTF8String:interstitialID]];
    }
    
    void showInterstitial(const char* interstitialID)
    {
        [PNInterstitialPlugin showInterstitialWithID:[NSString stringWithUTF8String:interstitialID]];
    }
    
    void hideInterstitial(const char* interstitialID)
    {
        [PNInterstitialPlugin hideInterstitialWithID:[NSString stringWithUTF8String:interstitialID]];
    }
    
    void removeInterstitial(const char* interstitialID)
    {
        [PNInterstitialPlugin removeInterstitialFromPoolWithID:[NSString stringWithUTF8String:interstitialID]];
    }
}
#endif