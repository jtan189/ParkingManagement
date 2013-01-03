using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParkingManagement.Billing
{
    // A customer credit card
    public class CreditCard
    {
        public int CardID { get; set; }
        public CreditCardType CardType { get; set; }
        public long CreditCardNumber { get; set; }

        // property for retrieved an obscured version of the card number
        public string ObscuredCardNumber {
            get { return string.Format("************{0}", CreditCardNumber.ToString().Substring(12)); }
        }

        // property for displaying the card as a string (to be used with comoboboxes)
        public string AsString
        {
            get
            {
                return string.Format("{0} ({1})", CardTypeToString(CardType), ObscuredCardNumber);
            }
        }

        // constructors
        public CreditCard()
        {
            CardID = -1;
            CreditCardNumber = -1;
            CardType = 0;
        }

        public CreditCard(long cardNum, CreditCardType cardType)
        {
            CreditCardNumber = cardNum;
            CardType = cardType;
        }

        // enum for the allowed credit card types
        public enum CreditCardType
        {
            VISA = 0,
            MASTERCARD = 1,
            AMERICAN_EXPRESS = 2
        }

        // convert the card type enum to a string
        public String CardTypeToString(CreditCardType cardType)
        {
            if (cardType == CreditCardType.AMERICAN_EXPRESS) {
                return "American Express";
            }
            else if (cardType == CreditCardType.MASTERCARD)
            {
                return "MasterCard";
            }
            else
            {
                return "Visa";
            }
        }
    }
}
