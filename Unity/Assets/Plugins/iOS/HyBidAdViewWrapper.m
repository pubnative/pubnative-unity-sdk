//
//  HyBidAdViewWrapper.m
//  UnityFramework
//
//  Created by Orkhan Alizada on 02.02.21.
//

#import "HyBidAdViewWrapper.h"

@interface HyBidAdViewWrapper ()

@property (nonatomic) BannerPosition bannerPosition;

@end

@implementation HyBidAdViewWrapper

+ (HyBidAdViewWrapper *)sharedInstance {
    static HyBidAdViewWrapper *_instance;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _instance = [[HyBidAdViewWrapper alloc] init];
    });
    return _instance;
}

- (void)loadWithObject:(NSString *)objectName withAppToken:(NSString *)appToken withPlacement:(NSString *)placement withAdId:(NSString *)adId withPosition:(BannerPosition)position
{
    self.gameObjectName = objectName;
    self.adId = adId;
    
    if (self.adView != nil) {
        self.adView = nil;
    }
    
    self.adView = [[HyBidAdView alloc] initWithSize:[HyBidAdSize SIZE_300x250]];
    
    if (position == 1) { // TOP
        self.bannerPosition = TOP;
    } else if (position == 2) { // BOTTOM
        self.bannerPosition = BOTTOM;
    }
    
    [HyBid initWithAppToken:appToken completion:^(BOOL isSuccess) {
        if (isSuccess) {
            [self.adView loadWithZoneID:placement andWithDelegate:self];
        }
    }];
}

- (void)show
{
    
}

- (void)hide
{
    
}

#pragma mark - HyBidAdView Delegate Methods

- (void)adView:(HyBidAdView *)adView didFailWithError:(NSError *)error {
    [self sendUnityMessage:@"OnHyBidAdError"];
}

- (void)adViewDidLoad:(HyBidAdView *)adView {
    [self sendUnityMessage:@"OnHyBidAdLoaded"];
}

- (void)adViewDidTrackClick:(HyBidAdView *)adView {
    [self sendUnityMessage:@"OnHyBidAdClicked"];
}

- (void)adViewDidTrackImpression:(HyBidAdView *)adView {
    [self sendUnityMessage:@"OnHyBidAdImpression"];
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
