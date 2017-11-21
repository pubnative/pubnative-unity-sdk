//
//  PNBannerWrapper.h
//  PNBannerWrapper
//
//  Created by Can Soykarafakili on 18.08.17.
//  Copyright © 2017 Can Soykarafakili. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "PNAdWrapper.h"

@interface PNBannerWrapper : PNAdWrapper

@property(nonatomic, strong) PNBanner *banner;

- (void)loadWithObject:(NSString*)objectName withAppToken:(NSString*)appToken withPlacement:(NSString*)placement;
- (void)showWithPosition:(NSInteger)position;
- (void)hide;
- (NSInteger)topPosition;
- (NSInteger)bottomPosition;

@end
