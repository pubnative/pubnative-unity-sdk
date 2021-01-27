//
 //  HyBidInterstitialWrapper.h
 //  UnityFramework
 //
 //  Created by Orkhan Alizada on 27.01.21.
 //

 #import <Foundation/Foundation.h>
 #import "UnityInterface.h"
 #import <HyBid/HyBid.h>

 @interface HyBidInterstitialWrapper : NSObject <HyBidInterstitialAdDelegate>

 @property (nonatomic, strong) NSString *gameObjectName;
 @property (nonatomic, strong) NSString *adId;
 @property (nonatomic, strong) HyBidInterstitialAd *interstitial;

 + (HyBidInterstitialWrapper *)sharedInstance;
 - (void)loadWithObject:(NSString *)objectName withAppToken:(NSString *)appToken withPlacement:(NSString *)placement withAdId:(NSString *)adId;
 - (void)show;
 - (void)hide;

 @end