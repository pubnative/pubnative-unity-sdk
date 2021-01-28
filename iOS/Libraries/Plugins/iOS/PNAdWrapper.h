//
//  PNAdWrapper.h
//  iOSUnityPlugin
//
//  Created by Can Soykarafakili on 18.08.17.
//  Copyright © 2017 Can Soykarafakili. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <Pubnative/Pubnative.h>

@interface PNAdWrapper : NSObject <PNLayoutLoadDelegate, PNLayoutTrackDelegate>

@property (nonatomic, strong) NSString *objectName;
@property (nonatomic, strong) NSString *adID;

@end
