//
//  PNAdWrapper.m
//  iOSUnityPlugin
//
//  Created by Can Soykarafakili on 18.08.17.
//  Copyright © 2017 Can Soykarafakili. All rights reserved.
//

#import "PNAdWrapper.h"
#import "UnityInterface.h"

@implementation PNAdWrapper

- (void)dealloc
{
    self.objectName = nil;
    self.bannerID = nil;
}

- (void)layoutDidFinishLoading:(PNLayout *)layout
{
    UnitySendMessage([self.objectName UTF8String], "OnPNLayoutLoadFinish", [self.bannerID UTF8String]);
}

- (void)layout:(PNLayout *)layout didFailLoading:(NSError *)error
{
    UnitySendMessage([self.objectName UTF8String], "OnPNLayoutLoadFailed", [self.bannerID UTF8String]);
}

- (void)layoutTrackImpression:(PNLayout *)layout
{
    UnitySendMessage([self.objectName UTF8String], "OnPNLayoutTrackImpression", [self.bannerID UTF8String]);
}

- (void)layoutTrackClick:(PNLayout *)layout
{
    UnitySendMessage([self.objectName UTF8String], "OnPNLayoutTrackClick", [self.bannerID UTF8String]);
}

@end
