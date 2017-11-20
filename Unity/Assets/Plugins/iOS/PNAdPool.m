//
//  PNAdPool.m
//  iOSUnityPlugin
//
//  Created by Can Soykarafakili on 22.08.17.
//  Copyright © 2017 Can Soykarafakili. All rights reserved.
//

#import "PNAdPool.h"

@implementation PNAdPool

- (void)dealloc
{
    self.bannerPool = nil;
    self.interstitialPool = nil;
}

- (instancetype)init
{
    self = [super init];
    if (self) {
        self.bannerPool = [NSMutableDictionary dictionary];
        self.interstitialPool = [NSMutableDictionary dictionary];
    }
    return self;
}

+ (PNAdPool *)sharedPool
{
    static PNAdPool* _pool;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _pool = [[PNAdPool alloc] init];
    });
    return _pool;
}

@end
