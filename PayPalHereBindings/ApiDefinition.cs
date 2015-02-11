using System;
using System.Drawing;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreLocation;

namespace PayPalHereSDK {

	// @protocol PPHSimpleCardReaderDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PPHSimpleCardReaderDelegate {

		// @optional -(void)didStartReaderDetection:(PPHCardReaderBasicInformation *)reader;
		[Export ("didStartReaderDetection:")]
		void DidStartReaderDetection (PPHCardReaderBasicInformation reader);

		// @optional -(void)didDetectReaderDevice:(PPHCardReaderBasicInformation *)reader;
		[Export ("didDetectReaderDevice:")]
		void DidDetectReaderDevice (PPHCardReaderBasicInformation reader);

		// @optional -(void)didRemoveReader:(PPHReaderType)readerType;
		[Export ("didRemoveReader:")]
		void DidRemoveReader (PPHReaderType readerType);

		// @optional -(void)didDetectCardSwipeAttempt;
		[Export ("didDetectCardSwipeAttempt")]
		void DidDetectCardSwipeAttempt ();

		// @optional -(void)didCompleteCardSwipe:(PPHCardSwipeData *)card;
		[Export ("didCompleteCardSwipe:")]
		void DidCompleteCardSwipe (PPHCardSwipeData card);

		// @optional -(void)didFailToReadCard;
		[Export ("didFailToReadCard")]
		void DidFailToReadCard ();

		// @optional -(void)didReceiveCardReaderMetadata:(PPHCardReaderMetadata *)metadata;
		[Export ("didReceiveCardReaderMetadata:")]
		void DidReceiveCardReaderMetadata (PPHCardReaderMetadata metadata);
	}

	// @protocol PPHCardReaderDelegate <PPHSimpleCardReaderDelegate>
	[Protocol, Model]
	interface PPHCardReaderDelegate : PPHSimpleCardReaderDelegate {

		// @optional -(void)didDetectUpgradeableReader:(PPHCardReaderBasicInformation *)reader withMessage:(NSString *)message isRequired:(BOOL)required isInitial:(BOOL)initial withEstimatedDuration:(NSTimeInterval)estimatedDuration;
		[Export ("didDetectUpgradeableReader:withMessage:isRequired:isInitial:withEstimatedDuration:")]
		void DidDetectUpgradeableReader (PPHCardReaderBasicInformation reader, string message, bool required, bool initial, double estimatedDuration);

		// @optional -(void)didFinishUpgradePreparations;
		[Export ("didFinishUpgradePreparations")]
		void DidFinishUpgradePreparations ();

		// @optional -(void)didUpgradeReader:(BOOL)successful withMessage:(NSString *)message;
		[Export ("didUpgradeReader:withMessage:")]
		void DidUpgradeReader (bool successful, string message);

		// @optional -(void)didReceiveReaderUpgradeStatusWithMessage:(NSString *)message currentStep:(NSInteger)currentStep totalSteps:(NSInteger)totalSteps completion:(float)completion;
		[Export ("didReceiveReaderUpgradeStatusWithMessage:currentStep:totalSteps:completion:")]
		void DidReceiveReaderUpgradeStatusWithMessage (string message, nint currentStep, nint totalSteps, float completion);

		// @optional -(void)didReceiveChipAndPinEvent:(PPHChipAndPinEvent *)event;
		[Export ("didReceiveChipAndPinEvent:")]
		void DidReceiveChipAndPinEvent (PPHChipAndPinEvent cpevent);
	}

	// @interface PPHCardReaderWatcher : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHCardReaderWatcher {

		// -(id)initWithDelegate:(id<PPHCardReaderDelegate>)delegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor (PPHCardReaderDelegate carddelegate);

		// -(id)initWithSimpleDelegate:(id<PPHSimpleCardReaderDelegate>)delegate;
		[Export ("initWithSimpleDelegate:")]
		IntPtr Constructor (PPHSimpleCardReaderDelegate carddelegate);
	}

	// @interface PPHCardReaderBasicInformation : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface PPHCardReaderBasicInformation : INSCoding {

		// @property (assign, nonatomic) PPHReaderType readerType;
		[Export ("readerType", ArgumentSemantic.UnsafeUnretained)]
		PPHReaderType ReaderType { get; set; }

		// @property (nonatomic, strong) NSString * family;
		[Export ("family", ArgumentSemantic.Retain)]
		string Family { get; set; }

		// @property (nonatomic, strong) NSString * friendlyName;
		[Export ("friendlyName", ArgumentSemantic.Retain)]
		string FriendlyName { get; set; }

		// @property (nonatomic, strong) NSString * protocolName;
		[Export ("protocolName", ArgumentSemantic.Retain)]
		string ProtocolName { get; set; }

		// +(PPHCardReaderBasicInformation *)anyReader;
		[Static, Export ("anyReader")]
		PPHCardReaderBasicInformation AnyReader ();
	}

	// @interface PPHCardReaderMetadata : PPHCardReaderBasicInformation
	[BaseType (typeof (PPHCardReaderBasicInformation))]
	interface PPHCardReaderMetadata {

		// @property (nonatomic, strong) NSString * serialNumber;
		[Export ("serialNumber", ArgumentSemantic.Retain)]
		string SerialNumber { get; set; }

		// @property (nonatomic, strong) NSString * firmwareRevision;
		[Export ("firmwareRevision", ArgumentSemantic.Retain)]
		string FirmwareRevision { get; set; }

		// @property (nonatomic) NSInteger batteryLevel;
		[Export ("batteryLevel")]
		nint BatteryLevel { get; set; }
	}

	// @interface PPHAmount : NSObject
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PPHAmount {

		// -(id)initWithPadding:(NSString *)amount inCurrency:(NSString *)currency;
		[Export ("initWithPadding:inCurrency:")]
		IntPtr Constructor (string amount, string currency);

		// -(id)initWithRounding:(NSDecimalNumber *)amount inCurrency:(NSString *)currency;
		[Export ("initWithRounding:inCurrency:")]
		IntPtr Constructor (NSDecimalNumber amount, string currency);

		// @property (readonly, nonatomic, strong) NSString * currencyCode;
		[Export ("currencyCode", ArgumentSemantic.Retain)]
		string CurrencyCode { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * amount;
		[Export ("amount", ArgumentSemantic.Retain)]
		NSDecimalNumber Amount { get; }

		// +(NSString *)localeCodeFromCountry:(NSString *)country;
		[Static, Export ("localeCodeFromCountry:")]
		string LocaleCodeFromCountry (string country);

		// +(NSString *)defaultCurrencyCodeInCountry:(NSString *)countryCode;
		[Static, Export ("defaultCurrencyCodeInCountry:")]
		string DefaultCurrencyCodeInCountry (string countryCode);

		// +(PPHAmount *)amountWithString:(NSString *)stringValue;
		[Static, Export ("amountWithString:")]
		PPHAmount AmountWithString (string stringValue);

		// +(PPHAmount *)amountWithDecimal:(NSDecimalNumber *)amount;
		[Static, Export ("amountWithDecimal:")]
		PPHAmount AmountWithDecimal (NSDecimalNumber amount);

		// +(PPHAmount *)amountWithDecimal:(NSDecimalNumber *)amount inCurrency:(NSString *)currency;
		[Static, Export ("amountWithDecimal:inCurrency:")]
		PPHAmount AmountWithDecimal (NSDecimalNumber amount, string currency);

		// +(PPHAmount *)amountWithString:(NSString *)stringValue inCurrency:(NSString *)currency;
		[Static, Export ("amountWithString:inCurrency:")]
		PPHAmount AmountWithString (string stringValue, string currency);

		// -(BOOL)isValid;
		[Export ("isValid")]
		bool IsValid ();

		// -(NSInteger)amountInCents;
		[Export ("amountInCents")]
		nint AmountInCents ();

		// -(NSInteger)isoCurrencyNumber;
		[Export ("isoCurrencyNumber")]
		nint IsoCurrencyNumber ();

		// -(NSString *)currencySymbol;
		[Export ("currencySymbol")]
		string CurrencySymbol ();

		// -(NSUInteger)digitsAfterDecimalSeperator;
		[Export ("digitsAfterDecimalSeperator")]
		nuint DigitsAfterDecimalSeperator ();

		// -(NSString *)decimalSeparator;
		[Export ("decimalSeparator")]
		string DecimalSeparator ();

		// -(NSString *)stringValue;
		[Export ("stringValue")]
		string StringValue ();

		// -(NSString *)stringValueWithoutCurrencySymbol;
		[Export ("stringValueWithoutCurrencySymbol")]
		string StringValueWithoutCurrencySymbol ();

		// -(NSString *)stringValueForPayment;
		[Export ("stringValueForPayment")]
		string StringValueForPayment ();

		// -(PPHAmount *)multiply:(NSDecimalNumber *)multiple;
		[Export ("multiply:")]
		PPHAmount Multiply (NSDecimalNumber multiple);

		// -(PPHAmount *)subtract:(NSDecimalNumber *)operand;
		[Export ("subtract:")]
		PPHAmount Subtract (NSDecimalNumber operand);

		// -(PPHAmount *)add:(NSDecimalNumber *)operand;
		[Export ("add:")]
		PPHAmount Add (NSDecimalNumber operand);

		// -(PPHAmount *)divideBy:(NSDecimalNumber *)divisor;
		[Export ("divideBy:")]
		PPHAmount DivideBy (NSDecimalNumber divisor);

		// -(PPHAmount *)multiplyByAmount:(PPHAmount *)multiple;
		[Export ("multiplyByAmount:")]
		PPHAmount MultiplyByAmount (PPHAmount multiple);

		// -(PPHAmount *)subtractAmount:(PPHAmount *)operand;
		[Export ("subtractAmount:")]
		PPHAmount SubtractAmount (PPHAmount operand);

		// -(PPHAmount *)addAmount:(PPHAmount *)operand;
		[Export ("addAmount:")]
		PPHAmount AddAmount (PPHAmount operand);

		// -(PPHAmount *)divideByAmount:(PPHAmount *)divisor;
		[Export ("divideByAmount:")]
		PPHAmount DivideByAmount (PPHAmount divisor);

		// -(PPHAmount *)roundedAmount;
		[Export ("roundedAmount")]
		PPHAmount RoundedAmount ();
	}

	// @protocol PPHInvoiceProtocol <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PPHInvoiceProtocol {

		// @required -(NSString *)currency;
		[Export ("currency")]
		[Abstract]
		string Currency ();

		// @required -(PPHAmount *)totalAmount;
		[Export ("totalAmount")]
		[Abstract]
		PPHAmount TotalAmount ();

		// @required -(NSString *)paypalInvoiceId;
		[Export ("paypalInvoiceId")]
		[Abstract]
		string PaypalInvoiceId ();

		// @required -(NSDictionary *)asDictionary;
		[Export ("asDictionary")]
		[Abstract]
		NSDictionary AsDictionary ();

		// @required -(NSString *)payerEmail;
		[Export ("payerEmail")]
		[Abstract]
		string PayerEmail ();
	}

	// @interface PPHCardReaderManager : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHCardReaderManager {

		// @property (readonly, nonatomic) BOOL isInPinRetryMode;
		[Export ("isInPinRetryMode")]
		bool IsInPinRetryMode { get; }

		// -(PPHReaderError)beginMonitoring;
		[Export ("beginMonitoring")]
		PPHReaderError BeginMonitoring ();

		// -(PPHReaderError)beginMonitoring:(PPHReaderTypeMask)readerTypes;
		[Export ("beginMonitoring:")]
		PPHReaderError BeginMonitoring (PPHReaderTypeMask readerTypes);

		// -(void)endMonitoring:(BOOL)unregisterForLocalNotifications;
		[Export ("endMonitoring:")]
		void EndMonitoring (bool unregisterForLocalNotifications);

		// -(PPHReaderError)activateReader:(PPHCardReaderBasicInformation *)readerOrNil;
		[Export ("activateReader:")]
		PPHReaderError ActivateReader (PPHCardReaderBasicInformation readerOrNil);

		// -(void)deactivateReader:(PPHCardReaderBasicInformation *)readerOrNil;
		[Export ("deactivateReader:")]
		void DeactivateReader (PPHCardReaderBasicInformation readerOrNil);

		// -(void)setPreferenceOrder:(NSArray *)arrayOfCardReaderBasicInfo;
		[Export ("setPreferenceOrder:")]
		void SetPreferenceOrder (NSObject [] arrayOfCardReaderBasicInfo);

		// -(NSArray *)availableDevices;
		[Export ("availableDevices")]
		NSObject [] AvailableDevices ();

		// -(void)beginUpgrade:(PPHCardReaderBasicInformation *)reader;
		[Export ("beginUpgrade:")]
		void BeginUpgrade (PPHCardReaderBasicInformation reader);

		// -(void)beginReaderUpdateUsingSDKUI_WithViewController:(UIViewController *)vc completionHandler:(void (^)(BOOL, NSString *))completionHandler;
		[Export ("beginReaderUpdateUsingSDKUI_WithViewController:completionHandler:")]
		void BeginReaderUpdateUsingSDKUI_WithViewController (UIViewController vc, Action<sbyte, NSString> completionHandler);
	}

	// @interface PPHCardSwipeData : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHCardSwipeData {

		// -(id)initWithTrack1:(NSString *)track1 track2:(NSString *)track2 readerSerial:(NSString *)serial withType:(NSString *)readerType andExtraInfo:(NSDictionary *)extraInfo;
		[Export ("initWithTrack1:track2:readerSerial:withType:andExtraInfo:")]
		IntPtr Constructor (string track1, string track2, string serial, string readerType, NSDictionary extraInfo);

		// -(id)initWithEncryptedTrack1:(NSString *)encryptedTrack1 encryptedTrack2:(NSString *)encryptedTrack2 readerSerial:(NSString *)serial keySerial:(NSString *)ksn withType:(NSString *)readerType;
		[Export ("initWithEncryptedTrack1:encryptedTrack2:readerSerial:keySerial:withType:")]
		IntPtr Constructor (string encryptedTrack1, string encryptedTrack2, string serial, string ksn, string readerType);

		// @property (nonatomic, strong) NSString * maskedCardNumber;
		[Export ("maskedCardNumber", ArgumentSemantic.Retain)]
		string MaskedCardNumber { get; set; }

		// @property (nonatomic, strong) NSString * cardholderName;
		[Export ("cardholderName", ArgumentSemantic.Retain)]
		string CardholderName { get; set; }

		// @property (nonatomic, strong) NSString * cardholderFirstName;
		[Export ("cardholderFirstName", ArgumentSemantic.Retain)]
		string CardholderFirstName { get; set; }

		// @property (nonatomic, strong) NSString * cardholderLastName;
		[Export ("cardholderLastName", ArgumentSemantic.Retain)]
		string CardholderLastName { get; set; }

		// @property (nonatomic) NSInteger expirationMonth;
		[Export ("expirationMonth")]
		nint ExpirationMonth { get; set; }

		// @property (nonatomic) NSInteger expirationYear;
		[Export ("expirationYear")]
		nint ExpirationYear { get; set; }

		// @property (nonatomic, strong) NSDictionary * extraData;
		[Export ("extraData", ArgumentSemantic.Retain)]
		NSDictionary ExtraData { get; set; }

		// @property (nonatomic, strong) NSString * ksn;
		[Export ("ksn", ArgumentSemantic.Retain)]
		string Ksn { get; set; }

		// @property (nonatomic, strong) NSString * serial;
		[Export ("serial", ArgumentSemantic.Retain)]
		string Serial { get; set; }

		// @property (nonatomic) BOOL signaturePresent;
		[Export ("signaturePresent")]
		bool SignaturePresent { get; set; }

		// @property (nonatomic, strong) PPHCardReaderMetadata * reader;
		[Export ("reader", ArgumentSemantic.Retain)]
		PPHCardReaderMetadata Reader { get; set; }

		// @property (readonly, nonatomic) PPHCreditCardType cardType;
		[Export ("cardType")]
		PPHCreditCardType CardType { get; }

		// -(BOOL)parseTracks:(NSString *)track1AndOr2;
		[Export ("parseTracks:")]
		bool ParseTracks (string track1AndOr2);

		// -(BOOL)parseTracksWithMaskedTrack1:(NSString *)maskedTrack1OrNil maskedTrack2:(NSString *)maskedTrack2OrNil;
		[Export ("parseTracksWithMaskedTrack1:maskedTrack2:")]
		bool ParseTracksWithMaskedTrack1 (string maskedTrack1OrNil, string maskedTrack2OrNil);

		// -(NSDictionary *)asDictionary;
		[Export ("asDictionary")]
		NSDictionary AsDictionary ();
	}

	// @interface PPHError : NSError
	[BaseType (typeof (NSError))]
	interface PPHError {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// -(id)initWithDomain:(NSString *)domain code:(NSInteger)code devMessage:(NSString *)devMessage;
		[Export ("initWithDomain:code:devMessage:")]
		IntPtr Constructor (string domain, nint code, string devMessage);

		// -(id)initWithDomain:(NSString *)domain code:(NSInteger)code devMessage:(NSString *)devMessage userMessage:(NSString *)userMessage;
		[Export ("initWithDomain:code:devMessage:userMessage:")]
		IntPtr Constructor (string domain, nint code, string devMessage, string userMessage);

		// @property (nonatomic, strong) NSString * apiMessage;
		[Export ("apiMessage", ArgumentSemantic.Retain)]
		string ApiMessage { get; set; }

		// @property (nonatomic, strong) NSString * apiShortMessage;
		[Export ("apiShortMessage", ArgumentSemantic.Retain)]
		string ApiShortMessage { get; set; }

		// @property (nonatomic, strong) NSArray * parameter;
		[Export ("parameter", ArgumentSemantic.Retain)]
		NSObject [] Parameter { get; set; }

		// @property (nonatomic, strong) NSString * correlationId;
		[Export ("correlationId", ArgumentSemantic.Retain)]
		string CorrelationId { get; set; }

		// @property (nonatomic, strong) NSDate * date;
		[Export ("date", ArgumentSemantic.Retain)]
		NSDate Date { get; set; }

		// @property (readonly, nonatomic) NSString * mappedMessage;
		[Export ("mappedMessage")]
		string MappedMessage { get; }

		// @property (readonly, nonatomic) NSString * devMessage;
		[Export ("devMessage")]
		string DevMessage { get; }

		// +(PPHError *)pphErrorWithNSError:(NSError *)error;
		[Static, Export ("pphErrorWithNSError:")]
		PPHError PphErrorWithNSError (NSError error);

		// -(BOOL)isCancelError;
		[Export ("isCancelError")]
		bool IsCancelError ();

		// -(PPHErrorCategory)errorCategory;
		[Export ("errorCategory")]
		PPHErrorCategory ErrorCategory ();

		// +(NSArray *)recentErrors;
		[Static, Export ("recentErrors")]
		NSObject [] RecentErrors ();

		// -(NSDictionary *)asDictionary;
		[Export ("asDictionary")]
		NSDictionary AsDictionary ();

		// -(void)createMappedMessage;
		[Export ("createMappedMessage")]
		void CreateMappedMessage ();
	}

	// @protocol PPHNetworkRequestDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PPHNetworkRequestDelegate {

		// @optional -(BOOL)beginRequest:(NSMutableURLRequest *)inRequest withID:(NSString *)identifier withHandler:(void (^)(NSHTTPURLResponse *, NSError *, NSData *))handler;
		[Export ("beginRequest:withID:withHandler:")]
		bool BeginRequest (NSMutableUrlRequest inRequest, string identifier, Action<NSHttpUrlResponse, NSError, NSData> handler);

		// @optional -(void)cancelOperationsForID:(NSString *)identifier;
		[Export ("cancelOperationsForID:")]
		void CancelOperationsForID (string identifier);

		// @optional -(void)modifyRequest:(NSMutableURLRequest *)inRequest;
		[Export ("modifyRequest:")]
		void ModifyRequest (NSMutableUrlRequest inRequest);

		// @optional -(void)requestCompleted:(NSURLRequest *)inRequest withResponse:(NSHTTPURLResponse *)inResponse data:(NSData *)data andError:(NSError *)error;
		[Export ("requestCompleted:withResponse:data:andError:")]
		void RequestCompleted (NSUrlRequest inRequest, NSHttpUrlResponse inResponse, NSData data, NSError error);
	}

	// @interface PPHCardNotPresentData : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHCardNotPresentData {

		// @property (nonatomic, strong) NSString * cardNumber;
		[Export ("cardNumber", ArgumentSemantic.Retain)]
		string CardNumber { get; set; }

		// @property (nonatomic, strong) NSDate * expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Retain)]
		NSDate ExpirationDate { get; set; }

		// @property (nonatomic, strong) NSString * cvv2;
		[Export ("cvv2", ArgumentSemantic.Retain)]
		string Cvv2 { get; set; }

		// @property (nonatomic, strong) NSString * postalCode;
		[Export ("postalCode", ArgumentSemantic.Retain)]
		string PostalCode { get; set; }

		// @property (nonatomic) BOOL scanned;
		[Export ("scanned")]
		bool Scanned { get; set; }

		// @property (readonly, nonatomic) BOOL isValid;
		[Export ("isValid")]
		bool IsValid { get; }

		// @property (readonly, nonatomic) PPHCreditCardType cardType;
		[Export ("cardType")]
		PPHCreditCardType CardType { get; }
	}

	// @interface PPHInvoiceConstants : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHInvoiceConstants {

		// +(PPHPaymentMethod)paymentMethodFromString:(NSString *)string;
		[Static, Export ("paymentMethodFromString:")]
		PPHPaymentMethod PaymentMethodFromString (string pmstring);

		// +(PPHPaymentMethodDetail)paymentMethodDetailFromString:(NSString *)string;
		[Static, Export ("paymentMethodDetailFromString:")]
		PPHPaymentMethodDetail PaymentMethodDetailFromString (string pmstring);

		// +(PPHInvoiceStatus)invoiceStatusFromString:(NSString *)string;
		[Static, Export ("invoiceStatusFromString:")]
		PPHInvoiceStatus InvoiceStatusFromString (string pmstring);

		// +(NSString *)stringFromPaymentMethod:(PPHPaymentMethod)method;
		[Static, Export ("stringFromPaymentMethod:")]
		string StringFromPaymentMethod (PPHPaymentMethod method);

		// +(NSString *)stringFromInvoiceStatus:(PPHInvoiceStatus)status;
		[Static, Export ("stringFromInvoiceStatus:")]
		string StringFromInvoiceStatus (PPHInvoiceStatus status);

		// +(NSString *)stringFromPaymentMethodDetail:(PPHPaymentMethodDetail)type;
		[Static, Export ("stringFromPaymentMethodDetail:")]
		string StringFromPaymentMethodDetail (PPHPaymentMethodDetail type);

		// +(BOOL)paymentMethodIsCreditCard:(PPHPaymentMethod)method;
		[Static, Export ("paymentMethodIsCreditCard:")]
		bool PaymentMethodIsCreditCard (PPHPaymentMethod method);

		// +(BOOL)paymentMethodMarksAsPaid:(PPHPaymentMethod)method;
		[Static, Export ("paymentMethodMarksAsPaid:")]
		bool PaymentMethodMarksAsPaid (PPHPaymentMethod method);

		// +(BOOL)invoiceStatusIsPaid:(PPHInvoiceStatus)status;
		[Static, Export ("invoiceStatusIsPaid:")]
		bool InvoiceStatusIsPaid (PPHInvoiceStatus status);

		// +(BOOL)invoiceStatusIsRefunded:(PPHInvoiceStatus)status;
		[Static, Export ("invoiceStatusIsRefunded:")]
		bool InvoiceStatusIsRefunded (PPHInvoiceStatus status);
	}

	// @interface PPHReceiptDestination : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHReceiptDestination {

		// @property (nonatomic, strong) NSString * destinationAddress;
		[Export ("destinationAddress", ArgumentSemantic.Retain)]
		string DestinationAddress { get; set; }

		// @property (assign, nonatomic) BOOL isEmail;
		[Export ("isEmail", ArgumentSemantic.UnsafeUnretained)]
		bool IsEmail { get; set; }
	}

	// @interface PPHTransactionRecord : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHTransactionRecord {

		// -(id)initWithTransactionId:(NSString *)transactionId;
		[Export ("initWithTransactionId:")]
		IntPtr Constructor (string transactionId);

		// -(id)initWithTransactionId:(NSString *)transactionId andWithPayPalInvoiceId:(NSString *)payPalInvoiceId;
		[Export ("initWithTransactionId:andWithPayPalInvoiceId:")]
		IntPtr Constructor (string transactionId, string payPalInvoiceId);

		// -(id)initWithAuthorizationId:(NSString *)authorizationId andWithInvoice:(PPHInvoice *)invoice;
		[Export ("initWithAuthorizationId:andWithInvoice:")]
		IntPtr Constructor (string authorizationId, PPHInvoice invoice);

		// @property (readonly, nonatomic, strong) PPHInvoice * invoice;
		[Export ("invoice", ArgumentSemantic.Retain)]
		PPHInvoice Invoice { get; }

		// @property (readonly, nonatomic, strong) NSDate * date;
		[Export ("date", ArgumentSemantic.Retain)]
		NSDate Date { get; }

		// @property (readonly, nonatomic, strong) NSString * transactionId;
		[Export ("transactionId", ArgumentSemantic.Retain)]
		string TransactionId { get; }

		// @property (readonly, nonatomic, strong) NSString * authorizationId;
		[Export ("authorizationId", ArgumentSemantic.Retain)]
		string AuthorizationId { get; }

		// @property (readonly, nonatomic, strong) NSString * payPalInvoiceId;
		[Export ("payPalInvoiceId", ArgumentSemantic.Retain)]
		string PayPalInvoiceId { get; }

		// @property (readonly, nonatomic, strong) NSString * correlationId;
		[Export ("correlationId", ArgumentSemantic.Retain)]
		string CorrelationId { get; }

		// @property (readonly, copy, nonatomic) NSString * customerId;
		[Export ("customerId")]
		string CustomerId { get; }

		// @property (readonly, copy, nonatomic) NSString * receiptPreferenceToken;
		[Export ("receiptPreferenceToken")]
		string ReceiptPreferenceToken { get; }

		// @property (readonly, nonatomic) BOOL paidWithPayPal;
		[Export ("paidWithPayPal")]
		bool PaidWithPayPal { get; }

		// @property (readonly, nonatomic) PPHPaymentMethod paymentMethod;
		[Export ("paymentMethod")]
		PPHPaymentMethod PaymentMethod { get; }

		// @property (readonly, nonatomic) PPHPaymentMethodDetail paymentMethodDetail;
		[Export ("paymentMethodDetail")]
		PPHPaymentMethodDetail PaymentMethodDetail { get; }

		// @property (readonly, nonatomic, strong) PPHCardSwipeData * encryptedCardData;
		[Export ("encryptedCardData", ArgumentSemantic.Retain)]
		PPHCardSwipeData EncryptedCardData { get; }

		// @property (readonly, nonatomic, strong) NSString * authCode;
		[Export ("authCode", ArgumentSemantic.Retain)]
		string AuthCode { get; }

		// @property (readonly, nonatomic, strong) NSString * transactionHandle;
		[Export ("transactionHandle", ArgumentSemantic.Retain)]
		string TransactionHandle { get; }
	}

	// @interface PPHPaymentResponse : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHPaymentResponse {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (nonatomic, strong) PPHError * error;
		[Export ("error", ArgumentSemantic.Retain)]
		PPHError Error { get; set; }

		// @property (nonatomic, strong) NSString * transactionId;
		[Export ("transactionId", ArgumentSemantic.Retain)]
		string TransactionId { get; set; }

		// @property (nonatomic, strong) NSString * authorizationId;
		[Export ("authorizationId", ArgumentSemantic.Retain)]
		string AuthorizationId { get; set; }

		// @property (nonatomic, strong) NSString * paypalInvoiceId;
		[Export ("paypalInvoiceId", ArgumentSemantic.Retain)]
		string PaypalInvoiceId { get; set; }

		// @property (nonatomic, strong) NSString * correlationId;
		[Export ("correlationId", ArgumentSemantic.Retain)]
		string CorrelationId { get; set; }

		// @property (copy, nonatomic) NSString * customerId;
		[Export ("customerId")]
		string CustomerId { get; set; }

		// @property (copy, nonatomic) NSString * receiptPreferenceToken;
		[Export ("receiptPreferenceToken")]
		string ReceiptPreferenceToken { get; set; }

		// @property (assign, nonatomic) BOOL isPaymentAuthorization;
		[Export ("isPaymentAuthorization", ArgumentSemantic.UnsafeUnretained)]
		bool IsPaymentAuthorization { get; set; }

		// -(NSDictionary *)asDictionary;
		[Export ("asDictionary")]
		NSDictionary AsDictionary ();
	}

	// @interface PPHChipAndPinAuthResponse : PPHPaymentResponse
	[BaseType (typeof (PPHPaymentResponse))]
	interface PPHChipAndPinAuthResponse {

		// @property (nonatomic, strong) NSString * authCode;
		[Export ("authCode", ArgumentSemantic.Retain)]
		string AuthCode { get; set; }

		// @property (nonatomic, strong) NSString * transactionHandle;
		[Export ("transactionHandle", ArgumentSemantic.Retain)]
		string TransactionHandle { get; set; }

		// @property (nonatomic, strong) NSArray * warnings;
		[Export ("warnings", ArgumentSemantic.Retain)]
		NSObject [] Warnings { get; set; }

		// @property (nonatomic, strong) NSString * responseCode;
		[Export ("responseCode", ArgumentSemantic.Retain)]
		string ResponseCode { get; set; }
	}

	// @interface PPHRefundEligibilityResponse : PPHPaymentResponse
	[BaseType (typeof (PPHPaymentResponse))]
	interface PPHRefundEligibilityResponse {

		// @property (assign, nonatomic) BOOL isEligible;
		[Export ("isEligible", ArgumentSemantic.UnsafeUnretained)]
		bool IsEligible { get; set; }
	}

	// @interface PPHTokenizedCustomerInformation : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHTokenizedCustomerInformation {

		// @property (nonatomic, strong) NSString * customerId;
		[Export ("customerId", ArgumentSemantic.Retain)]
		string CustomerId { get; set; }

		// @property (nonatomic, strong) NSString * maskedEmailAddress;
		[Export ("maskedEmailAddress", ArgumentSemantic.Retain)]
		string MaskedEmailAddress { get; set; }

		// @property (nonatomic, strong) NSString * maskedMobileNumber;
		[Export ("maskedMobileNumber", ArgumentSemantic.Retain)]
		string MaskedMobileNumber { get; set; }

		// @property (nonatomic, strong) NSString * receiptPreferenceToken;
		[Export ("receiptPreferenceToken", ArgumentSemantic.Retain)]
		string ReceiptPreferenceToken { get; set; }
	}

	// @interface PPHCardChargeResponse : PPHPaymentResponse
	[BaseType (typeof (PPHPaymentResponse))]
	interface PPHCardChargeResponse {

		// @property (nonatomic, strong) PPHTokenizedCustomerInformation * customer;
		[Export ("customer", ArgumentSemantic.Retain)]
		PPHTokenizedCustomerInformation Customer { get; set; }
	}

	// @interface PPHPaymentProcessor : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHPaymentProcessor {

		// -(void)beginRefund:(NSString *)transactionId forAmount:(PPHAmount *)amountOrNil completionHandler:(void (^)(PPHPaymentResponse *))completionHandler;
		[Export ("beginRefund:forAmount:completionHandler:")]
		void BeginRefund (string transactionId, PPHAmount amountOrNil, Action<PPHPaymentResponse> completionHandler);

		// -(void)beginNonPayPalRefundWithInvoiceId:(NSString *)invoiceId forAmount:(PPHAmount *)amountOrNil completionHandler:(void (^)(PPHPaymentResponse *))completionHandler;
		[Export ("beginNonPayPalRefundWithInvoiceId:forAmount:completionHandler:")]
		void BeginNonPayPalRefundWithInvoiceId (string invoiceId, PPHAmount amountOrNil, Action<PPHPaymentResponse> completionHandler);

		// -(void)beginCheckinPayment:(PPHLocationCheckin *)checkin forInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHPaymentResponse *))completionHandler;
		[Export ("beginCheckinPayment:forInvoice:completionHandler:")]
		void BeginCheckinPayment (PPHLocationCheckin checkin, PPHInvoiceProtocol invoice, Action<PPHPaymentResponse> completionHandler);

		// -(void)beginChipAndPinAuthorization:(PPHChipAndPinAuthEvent *)auth forInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHChipAndPinAuthResponse *))completionHandler;
		[Export ("beginChipAndPinAuthorization:forInvoice:completionHandler:")]
		void BeginChipAndPinAuthorization (PPHChipAndPinAuthEvent auth, PPHInvoiceProtocol invoice, Action<PPHChipAndPinAuthResponse> completionHandler);

		// -(void)beginCardPresentChargeAttempt:(PPHCardSwipeData *)card forInvoice:(id<PPHInvoiceProtocol>)invoice withSignature:(UIImage *)signature completionHandler:(void (^)(PPHCardChargeResponse *))completionHandler;
		[Export ("beginCardPresentChargeAttempt:forInvoice:withSignature:completionHandler:")]
		void BeginCardPresentChargeAttempt (PPHCardSwipeData card, PPHInvoiceProtocol invoice, UIImage signature, Action<PPHCardChargeResponse> completionHandler);

		// -(void)beginCardPresentAuthorizationAttempt:(PPHCardSwipeData *)card forInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHCardChargeResponse *))completionHandler;
		[Export ("beginCardPresentAuthorizationAttempt:forInvoice:completionHandler:")]
		void BeginCardPresentAuthorizationAttempt (PPHCardSwipeData card, PPHInvoiceProtocol invoice, Action<PPHCardChargeResponse> completionHandler);

		// -(void)beginCardNotPresentChargeAttempt:(PPHCardNotPresentData *)card forInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHCardChargeResponse *))completionHandler;
		[Export ("beginCardNotPresentChargeAttempt:forInvoice:completionHandler:")]
		void BeginCardNotPresentChargeAttempt (PPHCardNotPresentData card, PPHInvoiceProtocol invoice, Action<PPHCardChargeResponse> completionHandler);

		// -(void)beginCardNotPresentAuthorizationAttempt:(PPHCardNotPresentData *)card forInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHCardChargeResponse *))completionHandler;
		[Export ("beginCardNotPresentAuthorizationAttempt:forInvoice:completionHandler:")]
		void BeginCardNotPresentAuthorizationAttempt (PPHCardNotPresentData card, PPHInvoiceProtocol invoice, Action<PPHCardChargeResponse> completionHandler);

		// -(void)beginCaptureForTransactionId:(NSString *)txId withAmount:(PPHAmount *)amount andInvoice:(id<PPHInvoiceProtocol>)invoice asFinal:(BOOL)finalCapture withCompletionHandler:(void (^)(PPHCardChargeResponse *))completionHandler;
		[Export ("beginCaptureForTransactionId:withAmount:andInvoice:asFinal:withCompletionHandler:")]
		void BeginCaptureForTransactionId (string txId, PPHAmount amount, PPHInvoiceProtocol invoice, bool finalCapture, Action<PPHCardChargeResponse> completionHandler);

		// -(void)beginVoidForTransactionId:(NSString *)txId withInvoice:(id<PPHInvoiceProtocol>)invoice andCompletionHandler:(void (^)(PPHCardChargeResponse *))completionHandler;
		[Export ("beginVoidForTransactionId:withInvoice:andCompletionHandler:")]
		void BeginVoidForTransactionId (string txId, PPHInvoiceProtocol invoice, Action<PPHCardChargeResponse> completionHandler);

		// -(void)beginRecordingExternalPayment:(PPHPaymentMethod)paymentType withNote:(NSString *)note forInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHPaymentResponse *))completionHandler;
		[Export ("beginRecordingExternalPayment:withNote:forInvoice:completionHandler:")]
		void BeginRecordingExternalPayment (PPHPaymentMethod paymentType, string note, PPHInvoiceProtocol invoice, Action<PPHPaymentResponse> completionHandler);

		// -(void)provideSignature:(UIImage *)signature forTransaction:(PPHCardChargeResponse *)response andInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHError *))completionHandler;
		[Export ("provideSignature:forTransaction:andInvoice:completionHandler:")]
		void ProvideSignature (UIImage signature, PPHCardChargeResponse response, PPHInvoiceProtocol invoice, Action<PPHError> completionHandler);

		// -(void)checkRefundEligibilityForCardPresent:(PPHCardSwipeData *)card andInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHRefundEligibilityResponse *))completionHandler;
		[Export ("checkRefundEligibilityForCardPresent:andInvoice:completionHandler:")]
		void CheckRefundEligibilityForCardPresent (PPHCardSwipeData card, PPHInvoiceProtocol invoice, Action<PPHRefundEligibilityResponse> completionHandler);

		// -(void)checkRefundEligibilityForChipAndPin:(PPHChipAndPinAuthEvent *)auth andInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHRefundEligibilityResponse *))completionHandler;
		[Export ("checkRefundEligibilityForChipAndPin:andInvoice:completionHandler:")]
		void CheckRefundEligibilityForChipAndPin (PPHChipAndPinAuthEvent auth, PPHInvoiceProtocol invoice, Action<PPHRefundEligibilityResponse> completionHandler);

		// -(void)checkRefundEligibilityForDeclinedCardWithEvent:(PPHChipAndPinEventWithEmv *)event andInvoice:(id<PPHInvoiceProtocol>)invoice completionHandler:(void (^)(PPHRefundEligibilityResponse *))completionHandler;
		[Export ("checkRefundEligibilityForDeclinedCardWithEvent:andInvoice:completionHandler:")]
		void CheckRefundEligibilityForDeclinedCardWithEvent (PPHChipAndPinEventWithEmv cpevent, PPHInvoiceProtocol invoice, Action<PPHRefundEligibilityResponse> completionHandler);

		// -(void)beginSendReceipt:(PPHPaymentResponse *)payment to:(PPHReceiptDestination *)destination completionHandler:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("beginSendReceipt:to:completionHandler:")]
		void BeginSendReceipt (PPHPaymentResponse payment, PPHReceiptDestination destination, Action<PPHError> completionHandler);
	}

	// @interface PPHChipAndPinEvent : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHChipAndPinEvent {

		// @property (readonly, nonatomic) PPHChipAndPinEventType eventType;
		[Export ("eventType")]
		PPHChipAndPinEventType EventType { get; }

		// @property (readonly, nonatomic) PPHCardReaderMetadata * reader;
		[Export ("reader")]
		PPHCardReaderMetadata Reader { get; }
	}

	// @interface PPHChipAndPinDecisionEvent : PPHChipAndPinEvent
	[BaseType (typeof (PPHChipAndPinEvent))]
	interface PPHChipAndPinDecisionEvent {

		// -(NSInteger)count;
		[Export ("count")]
		nint Count ();

		// -(NSString *)applicationNameAtIndex:(NSInteger)ix;
		[Export ("applicationNameAtIndex:")]
		string ApplicationNameAtIndex (nint ix);

		// -(NSString *)applicationIdAtIndex:(NSInteger)ix;
		[Export ("applicationIdAtIndex:")]
		string ApplicationIdAtIndex (nint ix);
	}

	// @interface PPHChipAndPinDigitEvent : PPHChipAndPinEvent
	[BaseType (typeof (PPHChipAndPinEvent))]
	interface PPHChipAndPinDigitEvent {

		// @property (readonly, nonatomic) NSInteger digits;
		[Export ("digits")]
		nint Digits { get; }
	}

	// @interface PPHChipAndPinWaitingForPinEvent : PPHChipAndPinDigitEvent
	[BaseType (typeof (PPHChipAndPinDigitEvent))]
	interface PPHChipAndPinWaitingForPinEvent {

		// @property (readonly, nonatomic) BOOL lastAttempt;
		[Export ("lastAttempt")]
		bool LastAttempt { get; }
	}

	// @interface PPHChipAndPinPinIncorrectEvent : PPHChipAndPinEvent
	[BaseType (typeof (PPHChipAndPinEvent))]
	interface PPHChipAndPinPinIncorrectEvent {

		// @property (readonly, nonatomic) BOOL lastAttempt;
		[Export ("lastAttempt")]
		bool LastAttempt { get; }
	}

	// @interface PPHChipAndPinEventWithEmv : PPHChipAndPinEvent
	[BaseType (typeof (PPHChipAndPinEvent))]
	interface PPHChipAndPinEventWithEmv {

		// @property (readonly, nonatomic, strong) NSData * emvData;
		[Export ("emvData", ArgumentSemantic.Retain)]
		NSData EmvData { get; }

		// @property (readonly, nonatomic, strong) NSString * terminalId;
		[Export ("terminalId", ArgumentSemantic.Retain)]
		string TerminalId { get; }
	}

	// @interface PPHChipAndPinAuthEvent : PPHChipAndPinEventWithEmv
	[BaseType (typeof (PPHChipAndPinEventWithEmv))]
	interface PPHChipAndPinAuthEvent {

		// @property (readonly, nonatomic) BOOL pinVerified;
		[Export ("pinVerified")]
		bool PinVerified { get; }

		// @property (readonly, nonatomic) BOOL pinPresent;
		[Export ("pinPresent")]
		bool PinPresent { get; }

		// @property (readonly, nonatomic) BOOL signatureRequired;
		[Export ("signatureRequired")]
		bool SignatureRequired { get; }

		// @property (readonly, nonatomic) NSString * serial;
		[Export ("serial")]
		string Serial { get; }
	}

	// @interface PPHChipAndPinCancelEvent : PPHChipAndPinEvent
	[BaseType (typeof (PPHChipAndPinEvent))]
	interface PPHChipAndPinCancelEvent {

		// @property (readonly, nonatomic) BOOL cardRemoved;
		[Export ("cardRemoved")]
		bool CardRemoved { get; }
	}

	// @interface PPHChipAndPinCardChipBrokenEvent : PPHChipAndPinEvent
	[BaseType (typeof (PPHChipAndPinEvent))]
	interface PPHChipAndPinCardChipBrokenEvent {

		// @property (readonly, nonatomic) BOOL fallbackEnabled;
		[Export ("fallbackEnabled")]
		bool FallbackEnabled { get; }
	}

	// @interface PPHInvoiceTotals : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHInvoiceTotals {

		// -(id)initWithInvoice:(PPHInvoice *)invoice;
		[Export ("initWithInvoice:")]
		IntPtr Constructor (PPHInvoice invoice);

		// @property (readonly, nonatomic, strong) NSDecimalNumber * total;
		[Export ("total", ArgumentSemantic.Retain)]
		NSDecimalNumber Total { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * subTotal;
		[Export ("subTotal", ArgumentSemantic.Retain)]
		NSDecimalNumber SubTotal { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * itemTaxTotal;
		[Export ("itemTaxTotal", ArgumentSemantic.Retain)]
		NSDecimalNumber ItemTaxTotal { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * taxTotal;
		[Export ("taxTotal", ArgumentSemantic.Retain)]
		NSDecimalNumber TaxTotal { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * discountsTotal;
		[Export ("discountsTotal", ArgumentSemantic.Retain)]
		NSDecimalNumber DiscountsTotal { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * gratuityTotal;
		[Export ("gratuityTotal", ArgumentSemantic.Retain)]
		NSDecimalNumber GratuityTotal { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * shippingTotal;
		[Export ("shippingTotal", ArgumentSemantic.Retain)]
		NSDecimalNumber ShippingTotal { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * refundTotal;
		[Export ("refundTotal", ArgumentSemantic.Retain)]
		NSDecimalNumber RefundTotal { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * taxDetails;
		[Export ("taxDetails", ArgumentSemantic.Retain)]
		NSDictionary TaxDetails { get; }

		// -(NSDecimalNumber *)totalWithParts:(PPHInvoiceTotalParts)composition;
		[Export ("totalWithParts:")]
		NSDecimalNumber TotalWithParts (PPHInvoiceTotalParts composition);
	}

	// @interface PPHInvoicePayment : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHInvoicePayment {

		// -(id)initWithTransaction:(NSString *)transactionId forAmount:(PPHAmount *)amount withMethod:(PPHPaymentMethod)method andDetail:(PPHPaymentMethodDetail)detail onDate:(NSDate *)date;
		[Export ("initWithTransaction:forAmount:withMethod:andDetail:onDate:")]
		IntPtr Constructor (string transactionId, PPHAmount amount, PPHPaymentMethod method, PPHPaymentMethodDetail detail, NSDate date);

		// -(id)initWithDictionary:(NSDictionary *)representation;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary representation);

		// @property (readonly, nonatomic) PPHPaymentMethod paymentMethod;
		[Export ("paymentMethod")]
		PPHPaymentMethod PaymentMethod { get; }

		// @property (readonly, nonatomic) PPHPaymentMethodDetail paymentMethodDetail;
		[Export ("paymentMethodDetail")]
		PPHPaymentMethodDetail PaymentMethodDetail { get; }

		// @property (readonly, nonatomic, strong) NSString * transactionId;
		[Export ("transactionId", ArgumentSemantic.Retain)]
		string TransactionId { get; }

		// @property (readonly, nonatomic, strong) PPHAmount * amount;
		[Export ("amount", ArgumentSemantic.Retain)]
		PPHAmount Amount { get; }

		// @property (readonly, nonatomic, strong) NSDate * date;
		[Export ("date", ArgumentSemantic.Retain)]
		NSDate Date { get; }

		// @property (readonly, nonatomic) BOOL paidWithPayPal;
		[Export ("paidWithPayPal")]
		bool PaidWithPayPal { get; }

		// @property (readonly, nonatomic) NSString * latitude;
		[Export ("latitude")]
		string Latitude { get; }

		// @property (readonly, nonatomic) NSString * longitude;
		[Export ("longitude")]
		string Longitude { get; }

		// @property (readonly, nonatomic, strong) NSString * details;
		[Export ("details", ArgumentSemantic.Retain)]
		string Details { get; }

		// @property (readonly, nonatomic) PPHCreditCardType creditCardType;
		[Export ("creditCardType")]
		PPHCreditCardType CreditCardType { get; }

		// @property (readonly, nonatomic, strong) NSString * creditCardLastFourDigits;
		[Export ("creditCardLastFourDigits", ArgumentSemantic.Retain)]
		string CreditCardLastFourDigits { get; }

		// @property (readonly, nonatomic, strong) NSString * creditCardApplicationName;
		[Export ("creditCardApplicationName", ArgumentSemantic.Retain)]
		string CreditCardApplicationName { get; }

		// @property (readonly, nonatomic, strong) PPHAmount * fee;
		[Export ("fee", ArgumentSemantic.Retain)]
		PPHAmount Fee { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * cashTendered;
		[Export ("cashTendered", ArgumentSemantic.Retain)]
		NSDecimalNumber CashTendered { get; }

		// -(NSDictionary *)asDictionary;
		[Export ("asDictionary")]
		NSDictionary AsDictionary ();
	}

	// @interface PPHInvoiceItem : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface PPHInvoiceItem : INSCopying {

		// -(id)initWithDictionary:(NSDictionary *)representation;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary representation);

		// @property (readonly, nonatomic, strong) NSString * itemId;
		[Export ("itemId", ArgumentSemantic.Retain)]
		string ItemId { get; }

		// @property (readonly, nonatomic, strong) NSString * itemDetailId;
		[Export ("itemDetailId", ArgumentSemantic.Retain)]
		string ItemDetailId { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * quantity;
		[Export ("quantity", ArgumentSemantic.Retain)]
		NSDecimalNumber Quantity { get; }

		// @property (readonly, nonatomic, strong) NSString * name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }

		// @property (nonatomic, strong) NSString * itemDescription;
		[Export ("itemDescription", ArgumentSemantic.Retain)]
		string ItemDescription { get; set; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * unitPrice;
		[Export ("unitPrice", ArgumentSemantic.Retain)]
		NSDecimalNumber UnitPrice { get; }

		// @property (readonly, nonatomic, strong) NSDecimalNumber * taxRate;
		[Export ("taxRate", ArgumentSemantic.Retain)]
		NSDecimalNumber TaxRate { get; }

		// @property (readonly, nonatomic, strong) NSString * taxRateName;
		[Export ("taxRateName", ArgumentSemantic.Retain)]
		string TaxRateName { get; }

		// @property (nonatomic, strong) NSString * imageUrl;
		[Export ("imageUrl", ArgumentSemantic.Retain)]
		string ImageUrl { get; set; }

		// -(NSDictionary *)asDictionary;
		[Export ("asDictionary")]
		NSDictionary AsDictionary ();

		// -(PPHAmount *)roundedTotalInCurrency:(NSString *)currency;
		[Export ("roundedTotalInCurrency:")]
		PPHAmount RoundedTotalInCurrency (string currency);
	}

	// @interface PPHInvoiceContactInfo : NSObject <NSCoding, NSCopying>
	[BaseType (typeof (NSObject))]
	interface PPHInvoiceContactInfo : INSCoding, INSCopying {

		// -(id)initWithCountryCode:(NSString *)countryCode city:(NSString *)city addressLineOne:(NSString *)lineOne;
		[Export ("initWithCountryCode:city:addressLineOne:")]
		IntPtr Constructor (string countryCode, string city, string lineOne);

		// -(id)initWithDictionary:(NSDictionary *)representation;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary representation);

		// @property (nonatomic, strong) NSString * firstName;
		[Export ("firstName", ArgumentSemantic.Retain)]
		string FirstName { get; set; }

		// @property (nonatomic, strong) NSString * lastName;
		[Export ("lastName", ArgumentSemantic.Retain)]
		string LastName { get; set; }

		// @property (nonatomic, strong) NSString * businessName;
		[Export ("businessName", ArgumentSemantic.Retain)]
		string BusinessName { get; set; }

		// @property (nonatomic, strong) NSString * phoneNumber;
		[Export ("phoneNumber", ArgumentSemantic.Retain)]
		string PhoneNumber { get; set; }

		// @property (nonatomic, strong) NSString * faxNumber;
		[Export ("faxNumber", ArgumentSemantic.Retain)]
		string FaxNumber { get; set; }

		// @property (nonatomic, strong) NSString * website;
		[Export ("website", ArgumentSemantic.Retain)]
		string Website { get; set; }

		// @property (nonatomic, strong) NSString * customValue;
		[Export ("customValue", ArgumentSemantic.Retain)]
		string CustomValue { get; set; }

		// @property (nonatomic, strong) NSString * city;
		[Export ("city", ArgumentSemantic.Retain)]
		string City { get; set; }

		// @property (nonatomic, strong) NSString * countryCode;
		[Export ("countryCode", ArgumentSemantic.Retain)]
		string CountryCode { get; set; }

		// @property (nonatomic, strong) NSString * lineOne;
		[Export ("lineOne", ArgumentSemantic.Retain)]
		string LineOne { get; set; }

		// @property (nonatomic, strong) NSString * lineTwo;
		[Export ("lineTwo", ArgumentSemantic.Retain)]
		string LineTwo { get; set; }

		// @property (nonatomic, strong) NSString * postalCode;
		[Export ("postalCode", ArgumentSemantic.Retain)]
		string PostalCode { get; set; }

		// @property (nonatomic, strong) NSString * taxId;
		[Export ("taxId", ArgumentSemantic.Retain)]
		string TaxId { get; set; }

		// @property (nonatomic, strong) NSString * state;
		[Export ("state", ArgumentSemantic.Retain)]
		string State { get; set; }

		// -(BOOL)isValidInfo;
		[Export ("isValidInfo")]
		bool IsValidInfo ();

		// -(NSDictionary *)asDictionary;
		[Export ("asDictionary")]
		NSDictionary AsDictionary ();
	}

	// @interface PPHInvoiceItemContext : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHInvoiceItemContext {

	}

	// @interface PPHInvoice : NSObject <PPHInvoiceProtocol>
	[BaseType (typeof (NSObject))]
	interface PPHInvoice : PPHInvoiceProtocol {

		// -(id)initWithCurrency:(NSString *)currency;
		[Export ("initWithCurrency:")]
		IntPtr Constructor (string currency);

		// -(id)initWithDictionary:(NSDictionary *)representation;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary representation);

		// -(id)initWithDictionary:(NSDictionary *)representation context:(PPHInvoiceItemContext *)context;
		[Export ("initWithDictionary:context:")]
		IntPtr Constructor (NSDictionary representation, PPHInvoiceItemContext context);

		// -(id)initWithDictionary:(NSDictionary *)representation invoiceId:(NSString *)invoiceId context:(PPHInvoiceItemContext *)context;
		[Export ("initWithDictionary:invoiceId:context:")]
		IntPtr Constructor (NSDictionary representation, string invoiceId, PPHInvoiceItemContext context);

		// -(id)initWithItem:(NSString *)item forAmount:(PPHAmount *)amount;
		[Export ("initWithItem:forAmount:")]
		IntPtr Constructor (string item, PPHAmount amount);

		// @property (nonatomic, strong) NSDecimalNumber * discountAmount;
		[Export ("discountAmount", ArgumentSemantic.Retain)]
		NSDecimalNumber DiscountAmount { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * discountPercentage;
		[Export ("discountPercentage", ArgumentSemantic.Retain)]
		NSDecimalNumber DiscountPercentage { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * gratuity;
		[Export ("gratuity", ArgumentSemantic.Retain)]
		NSDecimalNumber Gratuity { get; set; }

		// @property (nonatomic, strong) NSString * paymentTerms;
		[Export ("paymentTerms", ArgumentSemantic.Retain)]
		string PaymentTerms { get; set; }

		// @property (nonatomic, strong) NSDate * dueDate;
		[Export ("dueDate", ArgumentSemantic.Retain)]
		NSDate DueDate { get; set; }

		// @property (nonatomic, strong) NSString * payerEmail;
		[Export ("payerEmail:")]
		void setPayerEmail(string email);

		// @property (readonly, nonatomic, strong) PPHInvoiceContactInfo * billingInfo;
		[Export ("billingInfo", ArgumentSemantic.Retain)]
		PPHInvoiceContactInfo BillingInfo { get; }

		// @property (readonly, nonatomic, strong) PPHInvoiceContactInfo * shippingInfo;
		[Export ("shippingInfo", ArgumentSemantic.Retain)]
		PPHInvoiceContactInfo ShippingInfo { get; }

		// @property (nonatomic, strong) NSDecimalNumber * shippingAmount;
		[Export ("shippingAmount", ArgumentSemantic.Retain)]
		NSDecimalNumber ShippingAmount { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * shippingTaxRate;
		[Export ("shippingTaxRate", ArgumentSemantic.Retain)]
		NSDecimalNumber ShippingTaxRate { get; set; }

		// @property (nonatomic, strong) NSString * shippingTaxRateName;
		[Export ("shippingTaxRateName", ArgumentSemantic.Retain)]
		string ShippingTaxRateName { get; set; }

		// @property (nonatomic) BOOL taxInclusive;
		[Export ("taxInclusive")]
		bool TaxInclusive { get; set; }

		// @property (nonatomic) BOOL taxCalculatedAfterDiscount;
		[Export ("taxCalculatedAfterDiscount")]
		bool TaxCalculatedAfterDiscount { get; set; }

		// @property (nonatomic, strong) NSString * customAmountName;
		[Export ("customAmountName", ArgumentSemantic.Retain)]
		string CustomAmountName { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * customAmountValue;
		[Export ("customAmountValue", ArgumentSemantic.Retain)]
		NSDecimalNumber CustomAmountValue { get; set; }

		// @property (nonatomic, strong) NSString * referrerCode;
		[Export ("referrerCode", ArgumentSemantic.Retain)]
		string ReferrerCode { get; set; }

		// @property (nonatomic, strong) NSString * cashierId;
		[Export ("cashierId", ArgumentSemantic.Retain)]
		string CashierId { get; set; }

		// @property (readonly, nonatomic, strong) NSString * currency;
		[Export ("currency:")]
		void setCurrency(string currency);

		// @property (readonly, nonatomic) NSString * paypalInvoiceId;
		[Export ("paypalInvoiceId:")]
		void setPaypalInvoiceId(string invoiceId);

		// @property (readonly, nonatomic) NSDate * createDate;
		[Export ("createDate")]
		NSDate CreateDate { get; }

		// @property (readonly, nonatomic) NSString * merchantReferenceNumber;
		[Export ("merchantReferenceNumber")]
		string MerchantReferenceNumber { get; }

		// @property (readonly, nonatomic) NSString * merchantMemo;
		[Export ("merchantMemo")]
		string MerchantMemo { get; }

		// @property (nonatomic, strong) PPHInvoicePayment * paymentInfo;
		[Export ("paymentInfo", ArgumentSemantic.Retain)]
		PPHInvoicePayment PaymentInfo { get; set; }

		// @property (readonly, nonatomic) NSArray * refunds;
		[Export ("refunds")]
		NSObject [] Refunds { get; }

		// @property (readonly, nonatomic) PPHInvoiceStatus status;
		[Export ("status")]
		PPHInvoiceStatus Status { get; }

		// @property (readonly, nonatomic) BOOL originatedOnWeb;
		[Export ("originatedOnWeb")]
		bool OriginatedOnWeb { get; }

		// @property (nonatomic, strong) NSString * terms;
		[Export ("terms", ArgumentSemantic.Retain)]
		string Terms { get; set; }

		// @property (readonly, nonatomic, strong) PPHInvoiceTotals * totals;
		[Export ("totals", ArgumentSemantic.Retain)]
		PPHInvoiceTotals Totals { get; }

		// @property (readonly, nonatomic) NSDecimalNumber * subTotal;
		[Export ("subTotal")]
		NSDecimalNumber SubTotal { get; }

		// @property (readonly, nonatomic) NSDecimalNumber * tax;
		[Export ("tax")]
		NSDecimalNumber Tax { get; }

		// @property (readonly, nonatomic) NSDecimalNumber * subTotalWithDiscounts;
		[Export ("subTotalWithDiscounts")]
		NSDecimalNumber SubTotalWithDiscounts { get; }

		// @property (readonly, nonatomic) NSDecimalNumber * totalDiscount;
		[Export ("totalDiscount")]
		NSDecimalNumber TotalDiscount { get; }

		// @property (readonly, nonatomic) NSDecimalNumber * refundTotal;
		[Export ("refundTotal")]
		NSDecimalNumber RefundTotal { get; }

		// @property (readonly, nonatomic) NSDecimalNumber * totalFees;
		[Export ("totalFees")]
		NSDecimalNumber TotalFees { get; }

		// @property (readonly, nonatomic) NSDictionary * taxDetails;
		[Export ("taxDetails")]
		NSDictionary TaxDetails { get; }

		// @property (readonly, nonatomic) PPHAmount * totalWithRefunds;
		[Export ("totalWithRefunds")]
		PPHAmount TotalWithRefunds { get; }

		// @property (readonly, nonatomic) NSArray * items;
		[Export ("items")]
		NSObject [] Items { get; }

		// @property (readonly, nonatomic) int itemCount;
		[Export ("itemCount")]
		int ItemCount { get; }

		// @property (nonatomic, strong) NSString * note;
		[Export ("note", ArgumentSemantic.Retain)]
		string Note { get; set; }

		// +(void)downloadInvoiceForInvoiceId:(NSString *)invoiceId context:(PPHInvoiceItemContext *)context completionHandler:(PPHInvoiceLoadCompletionHandler)completionHandler;
		[Static, Export ("downloadInvoiceForInvoiceId:context:completionHandler:")]
		void DownloadInvoiceForInvoiceId (string invoiceId, PPHInvoiceItemContext context, Action<PPHInvoice, PPHError> completionHandler);

		// +(void)downloadInvoiceForMerchantReferenceNumber:(NSString *)referenceNumber context:(PPHInvoiceItemContext *)context completionHandler:(PPHInvoiceLoadCompletionHandler)completionHandler;
		[Static, Export ("downloadInvoiceForMerchantReferenceNumber:context:completionHandler:")]
		void DownloadInvoiceForMerchantReferenceNumber (string referenceNumber, PPHInvoiceItemContext context, Action<PPHInvoice, PPHError> completionHandler);

		// -(instancetype)copyAsTemplate;
		[Export ("copyAsTemplate")]
		PPHInvoice CopyAsTemplate ();

		// -(void)readDictionary:(NSDictionary *)dictionary;
		[Export ("readDictionary:")]
		void ReadDictionary (NSDictionary dictionary);

		// -(NSDecimalNumber *)quantityByItemId:(NSString *)itemId;
		[Export ("quantityByItemId:")]
		NSDecimalNumber QuantityByItemId (string itemId);

		// -(PPHInvoiceItem *)invoiceItemWithId:(NSString *)itemId;
		[Export ("invoiceItemWithId:")]
		PPHInvoiceItem InvoiceItemWithId (string itemId);

		// -(PPHInvoiceItem *)invoiceItemWithId:(NSString *)itemId detailId:(NSString *)detailId;
		[Export ("invoiceItemWithId:detailId:")]
		PPHInvoiceItem InvoiceItemWithId (string itemId, string detailId);

		// -(PPHInvoiceItem *)addItemWithId:(NSString *)itemId name:(NSString *)name quantity:(NSDecimalNumber *)quantity unitPrice:(NSDecimalNumber *)unitPrice taxRate:(NSDecimalNumber *)taxRate taxRateName:(NSString *)taxRateName;
		[Export ("addItemWithId:name:quantity:unitPrice:taxRate:taxRateName:")]
		PPHInvoiceItem AddItemWithId (string itemId, string name, NSDecimalNumber quantity, NSDecimalNumber unitPrice, NSDecimalNumber taxRate, string taxRateName);

		// -(PPHInvoiceItem *)addItemWithId:(NSString *)itemId detailId:(NSString *)detailId name:(NSString *)name quantity:(NSDecimalNumber *)quantity unitPrice:(NSDecimalNumber *)unitPrice taxRate:(NSDecimalNumber *)taxRate taxRateName:(NSString *)taxRateName;
		[Export ("addItemWithId:detailId:name:quantity:unitPrice:taxRate:taxRateName:")]
		PPHInvoiceItem AddItemWithId (string itemId, string detailId, string name, NSDecimalNumber quantity, NSDecimalNumber unitPrice, NSDecimalNumber taxRate, string taxRateName);

		// -(void)incrementInvoiceItem:(PPHInvoiceItem *)item byQuantity:(NSDecimalNumber *)quantity;
		[Export ("incrementInvoiceItem:byQuantity:")]
		void IncrementInvoiceItem (PPHInvoiceItem item, NSDecimalNumber quantity);

		// -(void)removeAllItems;
		[Export ("removeAllItems")]
		void RemoveAllItems ();

		// -(void)refreshInvoice:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("refreshInvoice:")]
		void RefreshInvoice (Action<PPHError> completionHandler);

		// -(void)save:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("save:")]
		void Save (Action<PPHError> completionHandler);

		// -(void)send:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("send:")]
		void Send (Action<PPHError> completionHandler);

		// -(void)cancel:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("cancel:")]
		void Cancel (Action<PPHError> completionHandler);

		// -(void)getRefundDetails:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("getRefundDetails:")]
		void GetRefundDetails (Action<PPHError> completionHandler);

		// -(void)deleteInvoice:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("deleteInvoice:")]
		void DeleteInvoice (Action<PPHError> completionHandler);
	}

	// @interface PPHPaymentLimits : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHPaymentLimits {

		// @property (nonatomic, strong) NSDecimalNumber * minimumCardChargeAllowed;
		[Export ("minimumCardChargeAllowed", ArgumentSemantic.Retain)]
		NSDecimalNumber MinimumCardChargeAllowed { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * maximumCardChargeAllowed;
		[Export ("maximumCardChargeAllowed", ArgumentSemantic.Retain)]
		NSDecimalNumber MaximumCardChargeAllowed { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * signatureRequiredAbove;
		[Export ("signatureRequiredAbove", ArgumentSemantic.Retain)]
		NSDecimalNumber SignatureRequiredAbove { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * captureTolerance;
		[Export ("captureTolerance", ArgumentSemantic.Retain)]
		NSDecimalNumber CaptureTolerance { get; set; }
	}

	// @interface PPHAccessAccount : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface PPHAccessAccount : INSCoding {

		// -(id)initWithAccessToken:(NSString *)accessToken expires_in:(NSString *)seconds refreshUrl:(NSString *)refreshUrl details:(NSDictionary *)paypalAccessResponse;
		[Export ("initWithAccessToken:expires_in:refreshUrl:details:")]
		IntPtr Constructor (string accessToken, string seconds, string refreshUrl, NSDictionary paypalAccessResponse);

		// @property (readonly, nonatomic, strong) NSString * access_token;
		[Export ("access_token", ArgumentSemantic.Retain)]
		string Access_token { get; }

		// @property (readonly, nonatomic, strong) NSString * refresh_url;
		[Export ("refresh_url", ArgumentSemantic.Retain)]
		string Refresh_url { get; }

		// @property (readonly, nonatomic, strong) NSString * id_token;
		[Export ("id_token", ArgumentSemantic.Retain)]
		string Id_token { get; }

		// @property (readonly, nonatomic, strong) NSString * tokenScope;
		[Export ("tokenScope", ArgumentSemantic.Retain)]
		string TokenScope { get; }

		// @property (readonly, nonatomic, strong) NSDate * accessTokenExpiration;
		[Export ("accessTokenExpiration", ArgumentSemantic.Retain)]
		NSDate AccessTokenExpiration { get; }

		// @property (readonly, assign, nonatomic) PPHAccountStatus status;
		[Export ("status", ArgumentSemantic.UnsafeUnretained)]
		PPHAccountStatus Status { get; }

		// @property (readonly, nonatomic, strong) NSString * userId;
		[Export ("userId", ArgumentSemantic.Retain)]
		string UserId { get; }

		// @property (readonly, nonatomic, strong) NSString * email;
		[Export ("email", ArgumentSemantic.Retain)]
		string Email { get; }

		// @property (readonly, nonatomic, strong) NSArray * emails;
		[Export ("emails", ArgumentSemantic.Retain)]
		NSObject [] Emails { get; }

		// @property (readonly, nonatomic) PPHAvailablePaymentTypes availablePaymentTypes;
		[Export ("availablePaymentTypes")]
		PPHAvailablePaymentTypes AvailablePaymentTypes { get; }

		// @property (nonatomic, strong) PPHPaymentLimits * paymentLimits;
		[Export ("paymentLimits", ArgumentSemantic.Retain)]
		PPHPaymentLimits PaymentLimits { get; set; }

		// @property (readonly, nonatomic, strong) NSDictionary * extraInfo;
		[Export ("extraInfo", ArgumentSemantic.Retain)]
		NSDictionary ExtraInfo { get; }

		// @property (readonly, nonatomic, strong) NSString * currencyCode;
		[Export ("currencyCode", ArgumentSemantic.Retain)]
		string CurrencyCode { get; }

		// -(BOOL)hasCredentials;
		[Export ("hasCredentials")]
		bool HasCredentials ();
	}

	// @interface PPHMerchantInfo : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface PPHMerchantInfo : INSCoding {

		// @property (nonatomic, strong) NSURL * invoiceLogoUrl;
		[Export ("invoiceLogoUrl", ArgumentSemantic.Retain)]
		NSUrl InvoiceLogoUrl { get; set; }

		// @property (nonatomic, strong) PPHInvoiceContactInfo * invoiceContactInfo;
		[Export ("invoiceContactInfo", ArgumentSemantic.Retain)]
		PPHInvoiceContactInfo InvoiceContactInfo { get; set; }

		// @property (nonatomic, strong) NSString * currencyCode;
		[Export ("currencyCode", ArgumentSemantic.Retain)]
		string CurrencyCode { get; set; }

		// @property (nonatomic, strong) NSString * taxId;
		[Export ("taxId", ArgumentSemantic.Retain)]
		string TaxId { get; set; }

		// @property (nonatomic, strong) PPHAccessAccount * payPalAccount;
		[Export ("payPalAccount", ArgumentSemantic.Retain)]
		PPHAccessAccount PayPalAccount { get; set; }

		// @property (nonatomic, strong) NSString * terms;
		[Export ("terms", ArgumentSemantic.Retain)]
		string Terms { get; set; }

		// -(void)saveMerchantPreferencesWithTaxID:(NSString *)taxID ccStatementName:(NSString *)ccStatementName completionHandler:(void (^)(BOOL))completionHandler;
		[Export ("saveMerchantPreferencesWithTaxID:ccStatementName:completionHandler:")]
		void SaveMerchantPreferencesWithTaxID (string taxID, string ccStatementName, Action<sbyte> completionHandler);

		// -(void)getMerchantPreferencesWithCompletionHandler:(void (^)(NSString *, NSString *))completionHandler;
		[Export ("getMerchantPreferencesWithCompletionHandler:")]
		void GetMerchantPreferencesWithCompletionHandler (Action<NSString, NSString> completionHandler);
	}

	// @interface PPHLocationCheckin : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHLocationCheckin {

		// @property (readonly, nonatomic, strong) NSString * checkinId;
		[Export ("checkinId", ArgumentSemantic.Retain)]
		string CheckinId { get; }

		// @property (readonly, nonatomic, strong) NSString * customerId;
		[Export ("customerId", ArgumentSemantic.Retain)]
		string CustomerId { get; }

		// @property (readonly, nonatomic, strong) NSString * customerName;
		[Export ("customerName", ArgumentSemantic.Retain)]
		string CustomerName { get; }

		// @property (readonly, nonatomic, strong) NSDate * createDate;
		[Export ("createDate", ArgumentSemantic.Retain)]
		NSDate CreateDate { get; }

		// @property (readonly, nonatomic, strong) NSDate * updateDate;
		[Export ("updateDate", ArgumentSemantic.Retain)]
		NSDate UpdateDate { get; }

		// @property (readonly, nonatomic, strong) NSDate * expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Retain)]
		NSDate ExpirationDate { get; }

		// @property (readonly, nonatomic, strong) NSURL * photoUrl;
		[Export ("photoUrl", ArgumentSemantic.Retain)]
		NSUrl PhotoUrl { get; }

		// @property (readonly, nonatomic) PPHLocationCheckinStatus status;
		[Export ("status")]
		PPHLocationCheckinStatus Status { get; }

		// @property (nonatomic, strong) PPHAmount * gratuityAmount;
		[Export ("gratuityAmount", ArgumentSemantic.Retain)]
		PPHAmount GratuityAmount { get; set; }

		// @property (nonatomic, strong) NSDecimalNumber * gratuityPercentage;
		[Export ("gratuityPercentage", ArgumentSemantic.Retain)]
		NSDecimalNumber GratuityPercentage { get; set; }
	}

	// @protocol PPHLocationWatcherDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PPHLocationWatcherDelegate {

		// @optional -(void)locationWatcher:(PPHLocationWatcher *)watcher didDetectNewTab:(PPHLocationCheckin *)checkin;
		[Export ("locationWatcher:didDetectNewTab:")]
		void DidDetectNewTab (PPHLocationWatcher watcher, PPHLocationCheckin checkin);

		// @optional -(void)locationWatcher:(PPHLocationWatcher *)watcher didDetectRemovedTab:(PPHLocationCheckin *)checkin;
		[Export ("locationWatcher:didDetectRemovedTab:")]
		void DidDetectRemovedTab (PPHLocationWatcher watcher, PPHLocationCheckin checkin);

		// @optional -(void)locationWatcher:(PPHLocationWatcher *)watcher didReceiveError:(PPHError *)error;
		[Export ("locationWatcher:didReceiveError:")]
		void DidReceiveError (PPHLocationWatcher watcher, PPHError error);

		// @optional -(void)locationWatcher:(PPHLocationWatcher *)watcher didCompleteUpdate:(NSArray *)openTabs wasModified:(BOOL)wasModified;
		[Export ("locationWatcher:didCompleteUpdate:wasModified:")]
		void DidCompleteUpdate (PPHLocationWatcher watcher, NSObject [] openTabs, bool wasModified);
	}

	// @interface PPHLocationWatcher : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHLocationWatcher {

		// @property (nonatomic, unsafe_unretained) id<PPHLocationWatcherDelegate> delegate;
		[Export ("delegate", ArgumentSemantic.UnsafeUnretained)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, unsafe_unretained) id<PPHLocationWatcherDelegate> delegate;
		[Wrap ("WeakDelegate")]
		PPHLocationWatcherDelegate Delegate { get; set; }

		// @property (readonly, nonatomic, strong) NSString * locationId;
		[Export ("locationId", ArgumentSemantic.Retain)]
		string LocationId { get; }

		// @property (readonly, nonatomic, strong) NSArray * openTabs;
		[Export ("openTabs", ArgumentSemantic.Retain)]
		NSObject [] OpenTabs { get; }

		// -(void)updateNow;
		[Export ("updateNow")]
		void UpdateNow ();

		// -(void)updatePeriodically:(NSInteger)minimumUpdateIntervalSeconds withMaximumInterval:(NSInteger)maximumUpdateIntervalSeconds;
		[Export ("updatePeriodically:withMaximumInterval:")]
		void UpdatePeriodically (nint minimumUpdateIntervalSeconds, nint maximumUpdateIntervalSeconds);

		// -(void)stopPeriodicUpdates;
		[Export ("stopPeriodicUpdates")]
		void StopPeriodicUpdates ();
	}

	// @interface PPHLocation : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface PPHLocation : INSCopying {

		// -(id)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (nonatomic, strong) NSString * internalName;
		[Export ("internalName", ArgumentSemantic.Retain)]
		string InternalName { get; set; }

		// @property (nonatomic, strong) NSString * displayMessage;
		[Export ("displayMessage", ArgumentSemantic.Retain)]
		string DisplayMessage { get; set; }

		// @property (nonatomic, strong) PPHInvoiceContactInfo * contactInfo;
		[Export ("contactInfo", ArgumentSemantic.Retain)]
		PPHInvoiceContactInfo ContactInfo { get; set; }

		// @property (assign, nonatomic) CLLocationCoordinate2D location;
		[Export ("location", ArgumentSemantic.UnsafeUnretained)]
		CLLocationCoordinate2D Location { get; set; }

		// @property (assign, nonatomic) BOOL isAvailable;
		[Export ("isAvailable", ArgumentSemantic.UnsafeUnretained)]
		bool IsAvailable { get; set; }

		// @property (assign, nonatomic) BOOL isMobile;
		[Export ("isMobile", ArgumentSemantic.UnsafeUnretained)]
		bool IsMobile { get; set; }

		// @property (assign, nonatomic) PPHLocationCheckinType checkinType;
		[Export ("checkinType", ArgumentSemantic.UnsafeUnretained)]
		PPHLocationCheckinType CheckinType { get; set; }

		// @property (nonatomic, strong) NSURL * checkinExtensionUrl;
		[Export ("checkinExtensionUrl", ArgumentSemantic.Retain)]
		NSUrl CheckinExtensionUrl { get; set; }

		// @property (assign, nonatomic) PPHLocationCheckinExtensionType checkinExtensionType;
		[Export ("checkinExtensionType", ArgumentSemantic.UnsafeUnretained)]
		PPHLocationCheckinExtensionType CheckinExtensionType { get; set; }

		// @property (nonatomic, strong) NSString * logoUrl;
		[Export ("logoUrl", ArgumentSemantic.Retain)]
		string LogoUrl { get; set; }

		// @property (assign, nonatomic) NSInteger checkinDurationInMinutes;
		[Export ("checkinDurationInMinutes", ArgumentSemantic.UnsafeUnretained)]
		nint CheckinDurationInMinutes { get; set; }

		// @property (assign, nonatomic) PPHGratuityType gratuityType;
		[Export ("gratuityType", ArgumentSemantic.UnsafeUnretained)]
		PPHGratuityType GratuityType { get; set; }

		// @property (readonly, nonatomic, strong) NSString * locationId;
		[Export ("locationId", ArgumentSemantic.Retain)]
		string LocationId { get; }

		// @property (readonly, nonatomic, strong) NSDate * createDate;
		[Export ("createDate", ArgumentSemantic.Retain)]
		NSDate CreateDate { get; }

		// @property (readonly, nonatomic, strong) NSDate * updateDate;
		[Export ("updateDate", ArgumentSemantic.Retain)]
		NSDate UpdateDate { get; }

		// @property (readonly, nonatomic) PPHLocationStatus status;
		[Export ("status")]
		PPHLocationStatus Status { get; }

		// -(void)save:(void (^)(PPHError *))completionHandler;
		[Export ("save:")]
		void Save (Action<PPHError> completionHandler);

		// -(void)deleteLocation:(void (^)(PPHError *))completionHandler;
		[Export ("deleteLocation:")]
		void DeleteLocation (Action<PPHError> completionHandler);
	}

	// @interface PPHLocalManager : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHLocalManager {

		// -(PPHLocationWatcher *)watcherForLocationId:(NSString *)locationId withDelegate:(id<PPHLocationWatcherDelegate>)delegate;
		[Export ("watcherForLocationId:withDelegate:")]
		PPHLocationWatcher WatcherForLocationId (string locationId, PPHLocationWatcherDelegate wdelegate);

		// -(void)beginGetLocations:(void (^)(PPHError *, NSArray *))handler;
		[Export ("beginGetLocations:")]
		void BeginGetLocations (Action<PPHError, NSArray> handler);
	}

	// @protocol PPHLoggingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PPHLoggingDelegate {

		// @optional -(void)logPayPalHereError:(NSString *)message;
		[Export ("logPayPalHereError:")]
		void LogPayPalHereError (string message);

		// @optional -(void)logPayPalHereWarning:(NSString *)message;
		[Export ("logPayPalHereWarning:")]
		void LogPayPalHereWarning (string message);

		// @optional -(void)logPayPalHereInfo:(NSString *)message;
		[Export ("logPayPalHereInfo:")]
		void LogPayPalHereInfo (string message);

		// @optional -(void)logPayPalHereTrace:(NSString *)message;
		[Export ("logPayPalHereTrace:")]
		void LogPayPalHereTrace (string message);

		// @optional -(void)logPayPalHereDebug:(NSString *)message;
		[Export ("logPayPalHereDebug:")]
		void LogPayPalHereDebug (string message);

		// @optional -(void)logPayPalHereHardwareError:(NSString *)message;
		[Export ("logPayPalHereHardwareError:")]
		void LogPayPalHereHardwareError (string message);

		// @optional -(void)logPayPalHereHardwareWarning:(NSString *)message;
		[Export ("logPayPalHereHardwareWarning:")]
		void LogPayPalHereHardwareWarning (string message);

		// @optional -(void)logPayPalHereHardwareInfo:(NSString *)message;
		[Export ("logPayPalHereHardwareInfo:")]
		void LogPayPalHereHardwareInfo (string message);

		// @optional -(void)flush;
		[Export ("flush")]
		void Flush ();
	}

	// @interface PPHTransactionManagerEvent : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHTransactionManagerEvent {

		// @property (nonatomic) PPHTransactionEventType eventType;
		[Export ("eventType")]
		PPHTransactionEventType EventType { get; set; }
	}

	// @protocol PPHTransactionManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PPHTransactionManagerDelegate {

		// @required -(void)onPaymentEvent:(PPHTransactionManagerEvent *)event;
		[Export ("onPaymentEvent:")]
		[Abstract]
		void OnPaymentEvent (PPHTransactionManagerEvent tmevent);
	}

	// @protocol PPHTransactionControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface PPHTransactionControllerDelegate {

		// @required -(PPHTransactionControlActionType)onPreAuthorizeForInvoice:(PPHInvoice *)inv withPreAuthJSON:(NSMutableDictionary *)preAuthJSON;
		[Export ("onPreAuthorizeForInvoice:withPreAuthJSON:")]
		[Abstract]
		PPHTransactionControlActionType OnPreAuthorizeForInvoice (PPHInvoice inv, NSMutableDictionary preAuthJSON);

		// @required -(void)onPostAuthorize:(BOOL)didFail;
		[Export ("onPostAuthorize:")]
		[Abstract]
		void OnPostAuthorize (bool didFail);
	}

	// @interface PPHTransactionResponse : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHTransactionResponse {

		// @property (nonatomic, strong) PPHError * error;
		[Export ("error", ArgumentSemantic.Retain)]
		PPHError Error { get; set; }

		// @property (nonatomic, strong) PPHTransactionRecord * record;
		[Export ("record", ArgumentSemantic.Retain)]
		PPHTransactionRecord Record { get; set; }

		// @property (assign, nonatomic) BOOL isSignatureRequiredToFinalize;
		[Export ("isSignatureRequiredToFinalize", ArgumentSemantic.UnsafeUnretained)]
		bool IsSignatureRequiredToFinalize { get; set; }
	}

	// @interface PPHTransactionManager : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHTransactionManager {

		// @property (nonatomic, strong) PPHInvoice * currentInvoice;
		[Export ("currentInvoice", ArgumentSemantic.Retain)]
		PPHInvoice CurrentInvoice { get; set; }

		// @property (nonatomic, strong) PPHCardSwipeData * encryptedCardData;
		[Export ("encryptedCardData", ArgumentSemantic.Retain)]
		PPHCardSwipeData EncryptedCardData { get; set; }

		// @property (nonatomic, strong) PPHCardNotPresentData * manualEntryOrScannedCardData;
		[Export ("manualEntryOrScannedCardData", ArgumentSemantic.Retain)]
		PPHCardNotPresentData ManualEntryOrScannedCardData { get; set; }

		// @property (nonatomic, strong) PPHLocationCheckin * checkedInClient;
		[Export ("checkedInClient", ArgumentSemantic.Retain)]
		PPHLocationCheckin CheckedInClient { get; set; }

		// @property (readonly, nonatomic) BOOL isProcessingPayment;
		[Export ("isProcessingPayment")]
		bool IsProcessingPayment { get; }

		// @property (readonly, nonatomic) BOOL hasActiveTransaction;
		[Export ("hasActiveTransaction")]
		bool HasActiveTransaction { get; }

		// @property (assign, nonatomic) BOOL cardReaderMonitorEnabled;
		[Export ("cardReaderMonitorEnabled", ArgumentSemantic.UnsafeUnretained)]
		bool CardReaderMonitorEnabled { get; set; }

		// @property (assign, nonatomic) BOOL ignoreHardwareReaders;
		[Export ("ignoreHardwareReaders", ArgumentSemantic.UnsafeUnretained)]
		bool IgnoreHardwareReaders { get; set; }

		// @property (assign, nonatomic) BOOL shouldAppOverrideDefaultSignatureSetting;
		[Export ("shouldAppOverrideDefaultSignatureSetting", ArgumentSemantic.UnsafeUnretained)]
		bool ShouldAppOverrideDefaultSignatureSetting { get; set; }

		// -(void)beginPayment;
		[Export ("beginPayment")]
		void BeginPayment ();

		// -(void)beginPaymentWithAmount:(PPHAmount *)amount andName:(NSString *)itemName;
		[Export ("beginPaymentWithAmount:andName:")]
		void BeginPaymentWithAmount (PPHAmount amount, string itemName);

		// -(PPHError *)cancelPayment;
		[Export ("cancelPayment")]
		PPHError CancelPayment ();

		// -(void)authorizePaymentWithPaymentType:(PPHPaymentMethod)paymentMethod withCompletionHandler:(void (^)(PPHTransactionResponse *))completionHandler;
		[Export ("authorizePaymentWithPaymentType:withCompletionHandler:")]
		void AuthorizePaymentWithPaymentType (PPHPaymentMethod paymentMethod, Action<PPHTransactionResponse> completionHandler);

		// -(void)voidAuthorization:(PPHTransactionRecord *)authorizedTransactionRecord withCompletionHandler:(void (^)(PPHTransactionResponse *))completionHandler;
		[Export ("voidAuthorization:withCompletionHandler:")]
		void VoidAuthorization (PPHTransactionRecord authorizedTransactionRecord, Action<PPHTransactionResponse> completionHandler);

		// -(void)capturePaymentForAuthorization:(PPHTransactionRecord *)authorizedTransactionRecord withCompletionHandler:(void (^)(PPHTransactionResponse *))completionHandler;
		[Export ("capturePaymentForAuthorization:withCompletionHandler:")]
		void CapturePaymentForAuthorization (PPHTransactionRecord authorizedTransactionRecord, Action<PPHTransactionResponse> completionHandler);

		// -(void)processPaymentWithPaymentType:(PPHPaymentMethod)paymentType withTransactionController:(id<PPHTransactionControllerDelegate>)controller completionHandler:(void (^)(PPHTransactionResponse *))completionHandler;
		[Export ("processPaymentWithPaymentType:withTransactionController:completionHandler:")]
		void ProcessPaymentWithPaymentType (PPHPaymentMethod paymentType, PPHTransactionControllerDelegate controller, Action<PPHTransactionResponse> completionHandler);

		// -(void)processPaymentUsingSDKUI_WithPaymentType:(PPHPaymentMethod)paymentType withTransactionController:(id<PPHTransactionControllerDelegate>)controller withViewController:(UIViewController *)vc completionHandler:(void (^)(PPHTransactionResponse *))completionHandler;
		[Export ("processPaymentUsingSDKUI_WithPaymentType:withTransactionController:withViewController:completionHandler:")]
		void ProcessPaymentUsingSDKUI_WithPaymentType (PPHPaymentMethod paymentType, PPHTransactionControllerDelegate controller, UIViewController vc, Action<PPHTransactionResponse> completionHandler);

		// -(void)beginRefundUsingSDKUI_WithPaymentType:(PPHPaymentMethod)paymentType withViewController:(UIViewController *)vc record:(PPHTransactionRecord *)record amount:(PPHAmount *)amount completionHandler:(void (^)(PPHTransactionResponse *))completionHandler;
		[Export ("beginRefundUsingSDKUI_WithPaymentType:withViewController:record:amount:completionHandler:")]
		void BeginRefundUsingSDKUI_WithPaymentType (PPHPaymentMethod paymentType, UIViewController vc, PPHTransactionRecord record, PPHAmount amount, Action<PPHTransactionResponse> completionHandler);

		// -(void)provideSignature:(UIImage *)signature forTransaction:(PPHTransactionRecord *)previousTransaction completionHandler:(void (^)(PPHError *))completionHandler;
		[Export ("provideSignature:forTransaction:completionHandler:")]
		void ProvideSignature (UIImage signature, PPHTransactionRecord previousTransaction, Action<PPHError> completionHandler);

		// -(void)beginRefund:(PPHTransactionRecord *)previousTransaction forAmount:(PPHAmount *)amountOrNil completionHandler:(void (^)(PPHPaymentResponse *))completionHandler;
		[Export ("beginRefund:forAmount:completionHandler:")]
		void BeginRefund (PPHTransactionRecord previousTransaction, PPHAmount amountOrNil, Action<PPHPaymentResponse> completionHandler);

		// -(void)sendReceipt:(PPHTransactionRecord *)previousTransaction toRecipient:(PPHReceiptDestination *)destination completionHandler:(PPHInvoiceBasicCompletionHandler)completionHandler;
		[Export ("sendReceipt:toRecipient:completionHandler:")]
		void SendReceipt (PPHTransactionRecord previousTransaction, PPHReceiptDestination destination, Action<PPHError> completionHandler);
	}

	// @protocol PPHAnalyticsDelegate
	[Protocol, Model]
	interface PPHAnalyticsDelegate {

	}

	// @interface PPHAccessController : NSObject
	[BaseType (typeof (NSObject))]
	interface PPHAccessController {

		// -(void)setupMerchant:(PPHAccessAccount *)account completionHandler:(PPHAccessCompletionHandler)completionHandler;
		[Export ("setupMerchant:completionHandler:")]
		void SetupMerchant (PPHAccessAccount account, Action<PPHAccessResultType, PPHAccessAccount, NSDictionary> completionHandler);

		// -(void)refresh:(PPHAccessAccount *)account completionHandler:(PPHAccessTokenRefreshHandler)completionHandler;
		[Export ("refresh:completionHandler:")]
		void Refresh (PPHAccessAccount account, Action<PPHAccessResultType, PPHError> completionHandler);
	}

	// @interface PayPalHereSDK : NSObject
	[BaseType (typeof (NSObject))]
	interface PayPalHereSDK {

		// +(PPHCardReaderManager *)sharedCardReaderManager;
		[Static, Export ("sharedCardReaderManager")]
		PPHCardReaderManager SharedCardReaderManager ();

		// +(PPHLocalManager *)sharedLocalManager;
		[Static, Export ("sharedLocalManager")]
		PPHLocalManager SharedLocalManager ();

		// +(PPHPaymentProcessor *)sharedPaymentProcessor;
		[Static, Export ("sharedPaymentProcessor")]
		PPHPaymentProcessor SharedPaymentProcessor ();

		// +(PPHTransactionManager *)sharedTransactionManager;
		[Static, Export ("sharedTransactionManager")]
		PPHTransactionManager SharedTransactionManager ();

		// +(void)setNetworkDelegate:(id<PPHNetworkRequestDelegate>)delegate;
		[Static, Export ("setNetworkDelegate:")]
		void SetNetworkDelegate (PPHNetworkRequestDelegate nrdelegate);

		// +(id<PPHNetworkRequestDelegate>)networkDelegate;
		[Static, Export ("networkDelegate")]
		PPHNetworkRequestDelegate NetworkDelegate ();

		// +(void)reportNetworkRequestProgress:(NSURLRequest *)originalRequest currentStep:(NSInteger)currentStep totalSteps:(NSInteger)totalSteps currentStepPercentage:(NSInteger)wholeNumberCurrentPercentage totalStepPercentageEstimate:(NSInteger)wholeNumberTotalPercentage;
		[Static, Export ("reportNetworkRequestProgress:currentStep:totalSteps:currentStepPercentage:totalStepPercentageEstimate:")]
		void ReportNetworkRequestProgress (NSUrlRequest originalRequest, nint currentStep, nint totalSteps, nint wholeNumberCurrentPercentage, nint wholeNumberTotalPercentage);

		// +(void)setAnalyticsDelegate:(id<PPHAnalyticsDelegate>)delegate;
		[Static, Export ("setAnalyticsDelegate:")]
		void SetAnalyticsDelegate (PPHAnalyticsDelegate adelegate);

		// +(id<PPHAnalyticsDelegate>)analyticsDelegate;
		[Static, Export ("analyticsDelegate")]
		PPHAnalyticsDelegate AnalyticsDelegate ();

		// +(void)setLoggingDelegate:(id<PPHLoggingDelegate>)delegate;
		[Static, Export ("setLoggingDelegate:")]
		void SetLoggingDelegate (PPHLoggingDelegate ldelegate);

		// +(id<PPHLoggingDelegate>)loggingDelegate;
		[Static, Export ("loggingDelegate")]
		PPHLoggingDelegate LoggingDelegate ();

		// +(PPHMerchantInfo *)activeMerchant;
		[Static, Export ("activeMerchant")]
		PPHMerchantInfo ActiveMerchant ();

		// +(void)setActiveMerchant:(PPHMerchantInfo *)merchant withMerchantId:(NSString *)merchantId completionHandler:(PPHAccessCompletionHandler)completionHandler;
		[Static, Export ("setActiveMerchant:withMerchantId:completionHandler:")]
		void SetActiveMerchant (PPHMerchantInfo merchant, string merchantId, Action<PPHAccessResultType, PPHAccessAccount, NSDictionary> completionHandler);

		// +(BOOL)hasLocationAccess;
		[Static, Export ("hasLocationAccess")]
		bool HasLocationAccess ();

		// +(BOOL)askForLocationAccess;
		[Static, Export ("askForLocationAccess")]
		bool AskForLocationAccess ();

		// +(void)startWatchingLocation;
		[Static, Export ("startWatchingLocation")]
		void StartWatchingLocation ();

		// +(void)stopWatchingLocation;
		[Static, Export ("stopWatchingLocation")]
		void StopWatchingLocation ();

		// +(void)selectEnvironmentWithType:(PPHSDKServiceType)serviceType;
		[Static, Export ("selectEnvironmentWithType:")]
		void SelectEnvironmentWithType (PPHSDKServiceType serviceType);

		// +(NSString *)sdkVersion;
		[Static, Export ("sdkVersion")]
		string SdkVersion ();

		// +(NSString *)referrerCode;
		[Static, Export ("referrerCode")]
		string ReferrerCode ();

		// +(void)setReferrerCode:(NSString *)referrerCode;
		[Static, Export ("setReferrerCode:")]
		void SetReferrerCode (string referrerCode);

		// +(NSString *)baseURL;
		[Static, Export ("baseURL")]
		string BaseURL ();
	}
}
