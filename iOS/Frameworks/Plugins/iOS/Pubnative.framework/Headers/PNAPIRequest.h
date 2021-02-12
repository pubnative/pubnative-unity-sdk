//
//  Copyright © 2016 PubNative. All rights reserved.
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//

#import <Foundation/Foundation.h>

#import "PNAPIAdModel.h"

@class PNAPIRequest;

@protocol PNAPIRequestDelegate <NSObject>

- (void)requestDidStart:(PNAPIRequest*)request;
- (void)request:(PNAPIRequest*)request didLoad:(NSArray<PNAPIAdModel*>*)ads;
- (void)request:(PNAPIRequest*)request didFail:(NSError*)error;

@end

@protocol PNAPIRequestModes <NSObject>

- (void)setTestMode:(BOOL)enabled;
- (void)setCoppaMode:(BOOL)enabled;

@end

@interface PNAPIRequest : NSObject<PNAPIRequestModes>

- (void)startWithDelegate:(NSObject<PNAPIRequestDelegate>*)delegate;

- (void)addParameterWithKey:(NSString*)key value:(NSString*)value;
- (void)addParameterArrayWithKey:(NSString*)key array:(NSArray<NSString *>*)array;

@end
