//
//  PNInterstitialWrapper.m
//  Unity-iPhone
//
//  Created by Can Soykarafakili on 30.08.17.
//
//

#import "PNInterstitialWrapper.h"
#import "UnityInterface.h"

@implementation PNInterstitialWrapper

- (instancetype)init
{
    self = [super init];
    if (self) {
        self.interstitial = [[PNLargeLayout alloc] init];
    }
    return self;
}

- (void)loadWithObject:(NSString *)objectName withAppToken:(NSString *)appToken withPlacement:(NSString *)placement
{
    self.objectName = objectName;
    [self.interstitial loadWithAppToken:appToken placement:placement delegate:self];
}

- (void)show
{
    self.interstitial.viewDelegate = self;
    self.interstitial.trackDelegate = self;
    [self.interstitial show];
}

- (void)hide
{
    [self.interstitial hide];
}

- (void)layoutDidShow:(PNLayout *)layout
{
    UnityWillPause();
    UnityPause(true);
    if (self.objectName == nil || [self.objectName length] == 0) {
        NSLog(@"No object name has been defined.");
    } else {
        UnitySendMessage([self.objectName UTF8String], "OnPNLayoutViewShown", [self.adID UTF8String]);
    }
}

- (void)layoutDidHide:(PNLayout *)layout
{
    UnityWillResume();
    UnityPause(false);
    if (self.objectName == nil || [self.objectName length] == 0) {
        NSLog(@"No object name has been defined.");
    } else {
        UnitySendMessage([self.objectName UTF8String], "OnPNLayoutViewHidden", [self.adID UTF8String]);
    }
}

@end
