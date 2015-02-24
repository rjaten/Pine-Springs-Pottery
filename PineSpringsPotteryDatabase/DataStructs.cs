using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PineSpringsPotteryDatabase
{
    public struct CatalogPiece
    {
        public int pieceNo;
        public String pieceName;
        public String description;
        public Image picture;
        public List<CatalogPieceSize> sizeOptions;
        public override string ToString()
        {
            return pieceName;
        }
    }

    public struct CatalogPieceSize
    {
        public int sizeNo;
        public String dimensions;
        public String sizeDescription;
        public decimal basePrice;
        public decimal totalPounds;

        public override string ToString()
        {
            return totalPounds.ToString("f2") + " - " + dimensions;
        }
    }

    public struct Pattern
    {
        public int patternNo;
        public String patternName;
        public Image patternPicture;

        public override string ToString()
        {
            return patternName;
        }
    }

    public struct LineItem
    {
        public int pieceNo;
        public int sizeNo;
        public int orderNo;
        public int patternNo;
        public int quantity;
        public String customizations;
        public decimal price;
        public decimal totalPrice;
        public LineItemStatus status;
        public bool isGift;
        public String cardMessage;
        public Image customPicture;
    }

    public struct Customer
    {
        public int customerNo;
        public String firstName;
        public String lastName;
        public String street;
        public String city;
        public string state;
        public String zip;
        public String homePhone;
        public String mobilePhone;
        public String email;
        public String contactPreference;
        public int patternPreferenceNo;
        public decimal totalSpent;
        public decimal credit;
        public bool isHost;
        public String notes;
        public String taxExemptNo;
    }

    public struct WishList
    {
        public int customerNo;
        public int pieceNo;
        public int sizeNo;
        public int wishListItemNo;
        public int patternNo;
        public DateTime wishDate;
        public String customizations;
        public int quantity;
    }

    public enum LineItemStatus {ORDERED, MADE, DELIVERED, RETURNED, CANCELLED};

    public struct Show
    {
        public int showNo;
        public String showName;
        public DateTime showDate;
        public DateTime showTime;
        public String showLocation;
        public int showType;
        public decimal nonOrderSalesTotal;
        public decimal totalSales;
        public String description;
        public int hostNo;
    }

    public struct ShowType
    {
        public int showTypeNo;
        public String showTypeName;

        public override string ToString()
        {
            return showTypeName;
        }
    }

    public enum GuestResponse { YES, NO, NORESPONSE };

    public struct Guest
    {
        public String firstName;
        public String lastName;
        public int customerNo;
        public int showNo;
        public GuestResponse response;
    }

    public struct showPiece
    {
        public String pieceName;
        public String patternName;
        public decimal pieceSize;
        public int showNo;
        public int itemNo;
        public bool sold;
    }

    public struct Order
    {
        public int orderNo;
        public DateTime orderDate;
        public decimal subtotal;
        public decimal newSubtotal;
        public decimal total;
        public PaymentType paymentType;
        public String notes;
        public int customerNo;
        public int showNo;
        public bool taxable;
        public decimal discount;
        public decimal shipping;
        public decimal tax;
        public decimal amountPaid;
        public string checkNo;
        public List<LineItem> lineItems;
    }
    public enum PaymentType { CASH, CHECK, CREDITCARD };
}
