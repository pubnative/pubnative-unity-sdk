//
//  PNInterstitialWrapper.h
//  Unity-iPhone
//
//  Created by Can Soykarafakili on 30.08.17.
//
//

#import <Foundation/Foundation.h>
#import <Pubnative/Pubnative.h>
#import "PNAdWrapper.h"

@interface PNInterstitialWrapper : PNAdWrapper <PNLayoutViewDelegate>

@property(nonatomic, strong) PNLargeLayout *interstitial;

- (void)loadWithObject:(NSString*)objectName withAppToken:(NSString*)appToken withPlacement:(NSString*)placement;
- (void)show;
- (void)hide;

@end
