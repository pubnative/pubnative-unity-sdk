//
//  HyBidAdViewWrapper.h
//  UnityFramework
//
//  Created by Orkhan Alizada on 02.02.21.
//

#import <Foundation/Foundation.h>
#import "UnityInterface.h"
#import <HyBid/HyBid.h>

@interface HyBidAdViewWrapper : NSObject <HyBidAdViewDelegate>

@property (nonatomic, strong) NSString *gameObjectName;
@property (nonatomic, strong) NSString *adId;
@property (nonatomic, strong) HyBidAdView *adView;

@end
