#import "HyBidRewardedWrapper.h"
#import "PNAdPool.h"

@interface PNRewardedPlugin : NSObject

+ (void)loadRewardedWithObject:(NSString*)objectName
                      withAppToken:(NSString*)appToken
                     withPlacement:(NSString*)placement
                withRewardedID:(NSString *)rewardedID;

+ (void)showRewardedWithID:(NSString *)rewardedID;

+ (void)hideRewardedWithID:(NSString *)rewardedID;

+ (void)removeRewardedFromPoolWithID:(NSString *)rewardedID;

@end

static PNRewardedPlugin *_sharedInstance;

@implementation PNRewardedPlugin

+ (PNRewardedPlugin*)sharedInstance
{
    if(_sharedInstance == nil)
    {
        _sharedInstance = [[PNRewardedPlugin alloc] init];
    }
    return _sharedInstance;
}

+ (void)loadRewardedWithObject:(NSString *)objectName
                      withAppToken:(NSString *)appToken
                     withPlacement:(NSString *)placement
                withRewardedID:(NSString *)rewardedID
{
    [[HyBidRewardedWrapper sharedInstance] loadWithObject:objectName withAppToken:appToken withPlacement:placement withAdId:rewardedID];
}

+ (void)showRewardedWithID:(NSString *)rewardedID
{
    [[HyBidRewardedWrapper sharedInstance] show];
}

+ (void)hideRewardedWithID:(NSString *)rewardedID
{
    [[HyBidRewardedWrapper sharedInstance] hide];
}

+ (void)removeRewardedFromPoolWithID:(NSString *)rewardedID
{
    [[PNAdPool sharedPool].rewardedPool removeObjectForKey:rewardedID];
}

@end

#ifdef __cplusplus
extern "C"
{
    void loadRewarded(const char* obj, const char* appToken, const char* placement, const char* rewardedID)
    {
        [PNRewardedPlugin loadRewardedWithObject:[NSString stringWithUTF8String:obj]
                                            withAppToken:[NSString stringWithUTF8String:appToken]
                                           withPlacement:[NSString stringWithUTF8String:placement]
                                      withRewardedID:[NSString stringWithUTF8String:rewardedID]];
    }
    
    void showRewarded(const char* rewardedID)
    {
        [PNRewardedPlugin showRewardedWithID:[NSString stringWithUTF8String:rewardedID]];
    }
    
    void hideRewarded(const char* rewardedID)
    {
        [PNRewardedPlugin hideRewardedWithID:[NSString stringWithUTF8String:rewardedID]];
    }
    
    void removeRewarded(const char* rewardedID)
    {
        [PNRewardedPlugin removeRewardedFromPoolWithID:[NSString stringWithUTF8String:rewardedID]];
    }
}
#endif