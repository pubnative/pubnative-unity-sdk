//
//  PNAdPool.h
//  iOSUnityPlugin
//
//  Created by Can Soykarafakili on 22.08.17.
//  Copyright © 2017 Can Soykarafakili. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface PNAdPool : NSObject

@property (nonatomic, strong) NSMutableDictionary *bannerPool;
@property (nonatomic, strong) NSMutableDictionary *interstitialPool;
@property (nonatomic, strong) NSMutableDictionary *rewardedPool;

+ (PNAdPool *)sharedPool;

@end
