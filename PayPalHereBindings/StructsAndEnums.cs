using System;

namespace PayPalHereSDK {

	//[Native]
	public enum PPHReaderType : long /* nint */ {
		ePPHReaderTypeUnknown = 0,
		ePPHReaderTypeAudioJack = 1,
		ePPHReaderTypeDockPort = 2,
		ePPHReaderTypeChipAndPinBluetooth = 4
	}

	//[Native]
	public enum PPHReaderTypeMask : long /* nint */ {
		ePPHReaderTypeMaskNone = 0,
		ePPHReaderTypeMaskAudioJack = 1 << 1,
		ePPHReaderTypeMaskDockPort = 1 << 2,
		ePPHReaderTypeMaskChipAndPinBluetooth = 1 << 4,
		ePPHReaderTypeMaskAll = 1 | 2 | 4
	}

	//[Native]
	public enum PPHReaderError : long /* nint */ {
		ePPHReaderErrorNone = 0,
		ePPHReaderErrorAudioAccessDenied = 1,
		ePPHReaderErrorLocationNotAvailable = 2,
		ePPHReaderErrorConnectFailed = 3,
		ePPHReaderErrorNotAvailable = 4,
		ePPHReaderErrorTransactionNotValid = 5
	}

	//[Native]
	public enum PPHCreditCardType : long /* nint */ {
		ePPHCreditCardTypeUnknown = 0,
		ePPHCreditCardTypeVisa = 1,
		ePPHCreditCardTypeMastercard = 2,
		ePPHCreditCardTypeDiscover = 3,
		ePPHCreditCardTypeAmEx = 4,
		ePPHCreditCardTypeJCB = 5,
		ePPHCreditCardTypeMaestro = 6,
		ePPHCreditCardTypePayPal = 7
	}

	//[Native]
	public enum PPHErrorCategory : long /* nint */ {
		ePPHErrorCategoryUnknown,
		ePPHErrorCategoryOutage,
		ePPHErrorCategoryRetry,
		ePPHErrorCategoryBuyerDeclined,
		ePPHErrorCategorySellerDeclined,
		ePPHErrorCategoryAmbiguous,
		ePPHErrorCategoryData
	}

	public enum PPHPaymentMethod : uint {
		ePPHPaymentMethodUnknown = 0,
		ePPHPaymentMethodKey,
		ePPHPaymentMethodScan,
		ePPHPaymentMethodSwipe,
		ePPHPaymentMethodPaypal,
		ePPHPaymentMethodCheck,
		ePPHPaymentMethodCash,
		ePPHPaymentMethodChipCard,
		ePPHPaymentMethodEmvSwipe,
		ePPHPaymentMethodOther
	}

	public enum PPHPaymentMethodDetail : uint {
		ePPHPaymentMethodDetailNone = 0,
		ePPHPaymentMethodDetailBankTransfer = 5,
		ePPHPaymentMethodDetailDebitCard = 6,
		ePPHPaymentMethodDetailWireTransfer = 7
	}

	public enum PPHInvoiceStatus : uint {
		ePPHInvoiceStatusUnknown = 0,
		ePPHInvoiceStatusDraft = 1,
		ePPHInvoiceStatusSent = 2,
		ePPHInvoiceStatusPaid = 3,
		ePPHInvoiceStatusMarkedAsPaid = 4,
		ePPHInvoiceStatusCanceled = 5,
		ePPHInvoiceStatusRefunded = 6,
		ePPHInvoiceStatusPartialRefund = 7,
		ePPHInvoiceStatusReversed = 8,
		ePPHInvoiceStatusPending = 9,
		ePPHInvoiceStatusSaved = 10,
		ePPHInvoiceStatusMarkedAsRefunded = 11
	}

	//[Native]
	public enum PPHChipAndPinEventType : long /* nint */ {
		ePPHChipAndPinEventApproved = 1,
		ePPHChipAndPinEventDeclined = 2,
		ePPHChipAndPinEventAuthRequired = 3,
		ePPHChipAndPinEventFailed = 4,
		ePPHChipAndPinEventCancelled = 5,
		ePPHChipAndPinEventPinVerified = 6,
		ePPHChipAndPinEventPinIncorrect = 7,
		ePPHChipAndPinEventWaitingForPin = 8,
		ePPHChipAndPinEventPinBlocked = 9,
		ePPHChipAndPinEventPinDigitPressed = 10,
		ePPHChipAndPinEventCardBlocked = 11,
		ePPHChipAndPinEventCardInserted = 12,
		ePPHChipAndPinEventCardRemoved = 13,
		ePPHChipAndPinEventCardInvalid = 14,
		ePPHChipAndPinEventCardDeclined = 15,
		ePPHChipAndPinEventCardChipBroken = 16,
		ePPHChipAndPinEventDecisionRequired = 17
	}

	public enum PPHInvoiceTotalParts : uint {
		ePPHTotalIncludeNone = 0,
		ePPHTotalIncludeItems = 1 << 0,
		ePPHTotalIncludeTax = 1 << 1,
		ePPHTotalIncludeDiscount = 1 << 2,
		ePPHTotalIncludeGratuity = 1 << 3,
		ePPHTotalIncludeShipping = 1 << 4,
		ePPHTotalIncludeShippingTax = 1 << 5,
		ePPHTotalIncludeRefund = 1 << 6,
		ePPHTotalIncludeCustomAmount = 1 << 7,
		ePPHTotalSimpleTotal = ePPHTotalIncludeItems | ePPHTotalIncludeTax,
		ePPHTotalGrandTotal = ePPHTotalIncludeItems | ePPHTotalIncludeTax | ePPHTotalIncludeDiscount | ePPHTotalIncludeGratuity | ePPHTotalIncludeShipping | ePPHTotalIncludeShippingTax | ePPHTotalIncludeCustomAmount,
		ePPHTotalTaxTotal = ePPHTotalIncludeTax | ePPHTotalIncludeShippingTax,
		ePPHTotalGrandTotalInclusive = ePPHTotalIncludeItems | ePPHTotalIncludeDiscount | ePPHTotalIncludeGratuity | ePPHTotalIncludeShipping | ePPHTotalIncludeShippingTax | ePPHTotalIncludeCustomAmount
	}

	//[Native]
	public enum PPHAccountStatus : long /* nint */ {
		ePPHAccountStatusUnknown,
		ePPHAccountStatusReady,
		ePPHAccountStatusRestricted,
		ePPHAccountStatusEligible,
		ePPHAccountStatusIneligible
	}

	//[Native]
	public enum PPHAvailablePaymentTypes : long /* nint */ {
		ePPHAvailablePaymentTypeNone = 0,
		ePPHAvailablePaymentTypeCard = 1,
		ePPHAvailablePaymentTypeCheckin = 1 << 1,
		ePPHAvailablePaymentTypeChip = 1 << 2
	}

	//[Native]
	public enum PPHLocationCheckinType : long /* nint */ {
		ePPHCheckinTypeNone = 0,
		ePPHCheckinTypeStandard
	}

	//[Native]
	public enum PPHLocationCheckinExtensionType : long /* nint */ {
		ePPHCheckinExtensionTypeNone = 0,
		ePPHCheckinExtensionTypePostOpen
	}

	//[Native]
	public enum PPHLocationStatus : long /* nint */ {
		ePPHLocationStatusUnknown = 0,
		ePPHLocationStatusActive = 1,
		ePPHLocationStatusDeleted = 2
	}

	//[Native]
	public enum PPHGratuityType : long /* nint */ {
		ePPHGratuityTypeNone = 0,
		ePPHGratuityTypeStandard = 1
	}

	//[Native]
	public enum PPHAccessResultType : long /* nint */ {
		ePPHAccessResultSuccess,
		ePPHAccessResultFailed
	}

	//[Native]
	public enum PPHTransactionEventType : long /* nint */ {
		ePPHTransactionType_Idle,
		ePPHTransactionType_GettingPaymentInfo,
		ePPHTransactionType_DidStartReaderDetection,
		ePPHTransactionType_DidDetectReaderDevice,
		ePPHTransactionType_DidRemoveReader,
		ePPHTransactionType_CardReadBegun,
		ePPHTransactionType_CardDataReceived,
		ePPHTransactionType_FailedToReadCard,
		ePPHTransactionType_ProcessingPayment,
		ePPHTransactionType_WaitingForSignature,
		ePPHTransactionType_TransactionCancelled,
		ePPHTransactionType_TransactionDeclined
	}

	//[Native]
	public enum PPHTransactionControlActionType : long /* nint */ {
		ePPHTransactionType_Handled,
		ePPHTransactionType_Continue
	}

	//[Native]
	public enum PPHSDKServiceType : long /* nint */ {
		ePPHSDKServiceType_Live,
		ePPHSDKServiceType_Sandbox
	}

	//[Native]
	public enum PPHLocationCheckinStatus : long /* nint */ {
		ePPHCheckinStatusUnknown = 0,
		ePPHCheckinStatusActive,
		ePPHCheckinStatusCancelled,
		ePPHCheckinStatusExpired,
		ePPHCheckinStatusPaid,
		ePPHCheckinStatusLeft,
		ePPHCheckinStatusDeleted
	}
}

