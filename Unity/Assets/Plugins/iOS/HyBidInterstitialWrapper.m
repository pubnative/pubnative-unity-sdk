//
//  HyBidInterstitialWrapper.m
//  UnityFramework
//
//  Created by Orkhan Alizada on 27.01.21.
//

#import "HyBidInterstitialWrapper.h"

@implementation HyBidInterstitialWrapper

+ (HyBidInterstitialWrapper *)sharedInstance {
    static HyBidInterstitialWrapper *_instance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _instance = [[HyBidInterstitialWrapper alloc] init];
    });
    return _instance;
}

- (void)loadWithObject:(NSString *)objectName withAppToken:(NSString *)appToken withPlacement:(NSString *)placement withAdId:(NSString *)adId
{
    self.gameObjectName = objectName;
    self.adId = adId;
    
    if (self.interstitial != nil) {
        self.interstitial = nil;
    }
    
    self.interstitial = [[HyBidInterstitialAd alloc] initWithZoneID:placement andWithDelegate:self];
    
    [HyBid initWithAppToken:appToken completion:^(BOOL isSuccess) {
        if (isSuccess) {
            [self.interstitial load];
        }
    }];
}

- (void)show
{
    [self.interstitial show];
}

-(void)hide
{
    [self.interstitial hide];
}

#pragma mark - HyBidInterstitialAdDelegate

- (void)interstitialDidDismiss {
    [self sendUnityMessage:@"OnInterstitialDismissed"];
}

- (void)interstitialDidFailWithError:(NSError *)error {
    NSString *errorMessage = [NSString stringWithFormat:@"OnInterstitialLoadFailed, %@", error.localizedDescription];
    [self sendUnityMessage:errorMessage];
}

- (void)interstitialDidLoad {
    [self sendUnityMessage:@"OnInterstitialLoaded"];
}

- (void)interstitialDidTrackClick {
    [self sendUnityMessage:@"OnInterstitialClick"];
}

- (void)interstitialDidTrackImpression {
    [self sendUnityMessage:@"OnInterstitialImpression"];
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