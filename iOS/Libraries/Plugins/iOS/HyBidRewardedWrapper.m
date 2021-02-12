//
//  HyBidRewardedWrapper.m
//  UnityFramework
//
//  Created by Orkhan Alizada on 28.01.21.
//

#import "HyBidRewardedWrapper.h"

@implementation HyBidRewardedWrapper

+ (HyBidRewardedWrapper *)sharedInstance {
    static HyBidRewardedWrapper *_instance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _instance = [[HyBidRewardedWrapper alloc] init];
    });
    return _instance;
}

- (void)loadWithObject:(NSString *)objectName withAppToken:(NSString *)appToken withPlacement:(NSString *)placement withAdId:(NSString *)adId
{
    self.gameObjectName = objectName;
    self.adId = adId;
    
    if (self.rewarded != nil) {
        self.rewarded = nil;
    }
    
    self.rewarded = [[HyBidRewardedAd alloc] initWithZoneID:placement andWithDelegate:self];
    
    [HyBid initWithAppToken:appToken completion:^(BOOL isSuccess) {
        if (isSuccess) {
            [self.rewarded load];
        }
    }];
}

- (void)show
{
    [self.rewarded show];
}

- (void)hide
{
    [self.rewarded hide];
}

#pragma mark - HyBidRewardedAdDelegate

- (void)onReward {
    [self sendUnityMessage:@"onReward"];
}

- (void)rewardedDidDismiss {
    [self sendUnityMessage:@"OnRewardedClosed"];
}

- (void)rewardedDidFailWithError:(NSError *)error {
    [self sendUnityMessage:@"OnRewardedLoadFailed"];
}

- (void)rewardedDidLoad {
    [self sendUnityMessage:@"OnRewardedLoaded"];
}

- (void)rewardedDidTrackClick {
    [self sendUnityMessage:@"OnRewardedClick"];
}

- (void)rewardedDidTrackImpression {
    [self sendUnityMessage:@"OnRewardedOpened"];
}

#pragma mark - Helper Methods

- (void)sendUnityMessage:(NSString *)message
{
    const char *gameObjectName = [self.gameObjectName UTF8String];
    const char *adId = [self.adId UTF8String];
    const char *newMessage = [message UTF8String];
    UnitySendMessage(gameObjectName, newMessage, adId);
}

@end
