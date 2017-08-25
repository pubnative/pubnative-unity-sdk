//
//  PNBannerWrapper.m
//  PNBannerWrapper
//
//  Created by Can Soykarafakili on 18.08.17.
//  Copyright © 2017 Can Soykarafakili. All rights reserved.
//

#import "PNBannerWrapper.h"

@implementation PNBannerWrapper

- (void)dealloc
{
    self.banner = nil;
}

- (instancetype)init
{
    self = [super init];
    if (self) {
        self.banner = [[PNBanner alloc] init];
    }
    return self;
}

- (void)loadWithObject:(NSString *)objectName withAppToken:(NSString *)appToken withPlacement:(NSString *)placement
{
    self.objectName = objectName;
    [self.banner loadWithAppToken:appToken placement:placement delegate:self];
}

- (void)showWithPosition:(NSInteger)position
{
    self.banner.trackDelegate = self;
    if (position == [self topPosition]) {
        [self.banner showWithPosition:BANNER_POSITION_TOP];
    } else if (position == [self bottomPosition]) {
        [self.banner showWithPosition:BANNER_POSITION_BOTTOM];
    }
}

- (NSInteger)topPosition
{
    return 1;
}

- (NSInteger)bottomPosition
{
    return 2;
}

- (void)hide
{
    [self.banner hide];
}

@end
