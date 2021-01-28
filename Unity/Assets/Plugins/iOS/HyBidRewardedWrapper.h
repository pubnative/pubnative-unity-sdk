//
//  HyBidRewardedWrapper.h
//  UnityFramework
//
//  Created by Orkhan Alizada on 28.01.21.
//

#import <Foundation/Foundation.h>
#import "UnityInterface.h"
#import <HyBid/HyBid.h>

@interface HyBidRewardedWrapper : NSObject <HyBidRewardedAdDelegate>

@property (nonatomic, strong) NSString *gameObjectName;
@property (nonatomic, strong) NSString *adId;
@property (nonatomic, strong) HyBidRewardedAd *rewarded;

+ (HyBidRewardedWrapper *)sharedInstance;
- (void)loadWithObject:(NSString *)objectName withAppToken:(NSString *)appToken withPlacement:(NSString *)placement withAdId:(NSString *)adId;
- (void)show;
- (void)hide;

@end
