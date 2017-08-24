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
    if (self.objectName == nil || [self.objectName length] == 0) {
        NSLog(@"No object name has been defined.");
    } else {
        UnitySendMessage([self.objectName UTF8String], "OnPNLayoutLoadFinish", [self.bannerID UTF8String]);
    }
}

- (void)layout:(PNLayout *)layout didFailLoading:(NSError *)error
{
    if (self.objectName == nil || [self.objectName length] == 0) {
        NSLog(@"No object name has been defined.");
    } else {
        UnitySendMessage([self.objectName UTF8String], "OnPNLayoutLoadFailed", [self.bannerID UTF8String]);
    }
}

- (void)layoutTrackImpression:(PNLayout *)layout
{
    NSLog(@"Impression tracked");
}

- (void)layoutTrackClick:(PNLayout *)layout
{
    NSLog(@"Click tracked");
}

@end
