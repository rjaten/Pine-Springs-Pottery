using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PineSpringsPotteryDatabase
{
    class OrderMethods
    {
        // DataGridView and Order that needs to be passed in through constructor
        private DataGridView dgvLineItems = new DataGridView();
        private Order order = new Order();

        // Overloaded Constructor to insantiate necessary variables 
        public OrderMethods(DataGridView pItems,Order pOrder)
        {
            dgvLineItems = pItems;
            order = pOrder;
        }

        //show line items in datagrid view
        private void displayLineItems()
        {
            
            dgvLineItems.Rows.Clear();

            // For each item add it to the datagridview
            foreach (LineItem item in order.lineItems)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(dgvLineItems);
                newRow.Cells[0].Value = DatabaseAccess.GetPieceByNo(item.pieceNo).pieceName;
                newRow.Cells[1].Value = DatabaseAccess.GetPieceSizeByNo(item.pieceNo, item.sizeNo).totalPounds.ToString();
                newRow.Cells[2].Value = DatabaseAccess.GetPatternByNo(item.patternNo).patternName;
                newRow.Cells[3].Value = item.quantity.ToString();
                newRow.Cells[4].Value = item.price.ToString("f2");
                newRow.Cells[5].Value = item.totalPrice.ToString("f2");
                newRow.Cells[6].Value = item.status.ToString();
                newRow.Cells[7].Value = item.customizations;
                newRow.Cells[8].Value = item.isGift;
                newRow.Cells[9].Value = item.cardMessage;
                dgvLineItems.Rows.Add(newRow);
            }
        }

        //Gets all existing items for current new order
        private void getExistingItems()
        {
            order.lineItems = new List<LineItem>();
            List<LineItem> items;

            if (order.orderNo > 0)
            {
                items = DatabaseAccess.getLineItems(order.orderNo);

                foreach (LineItem item in items)
                {
                    order.lineItems.Add(item);
                }
            }

            displayLineItems();
        }

        //private decimal CalculateCurrency()
        //{

        //    decimal subtotal = 0;
        //    decimal discount = 0;
        //    decimal newSubtotal = 0;
        //    decimal tax = 0;
        //    decimal total = 0;
        //    decimal leftoverCredit = 0;
        //    if (dgvLineItems.RowCount < 0)
        //         return;
        //    foreach (LineItem item in order.lineItems)
        //    {
        //        if (item.status != LineItemStatus.CANCELLED && item.status != LineItemStatus.RETURNED)
        //            subtotal += decimal.Round(item.totalPrice, 2);
        //    }
        //        if (rbDollarDiscount.Checked)
        //            discount = Decimal.Round(nudDollarDiscount.Value + order.discount, 2);
        //        else
        //            discount = Decimal.Round(nudPercentDiscount.Value / 100.0m * subtotal + order.discount, 2);
        //        discountTextBox.Text = discount.ToString("f2");

        //        if (ccbCustomerCredit.Checked)
        //        {
        //            discount += Decimal.Round(Convert.ToDecimal(txtCustomerCredit.Text), 2);
        //            leftoverCredit = 0.0m;
        //        }
        //        else
        //            leftoverCredit = Decimal.Round(Convert.ToDecimal(txtCustomerCredit.Text), 2);

        //        if (discount > subtotal)
        //        {
        //            leftoverCredit += Decimal.Round(discount - subtotal, 2);
        //            discount = decimal.Round(subtotal, 2);
        //        }
        //        discountTextBox.Text = discount.ToString("f2");

        //        newSubtotal = Decimal.Round(subtotal - discount, 2);
        //        txtNewTotal.Text = newSubtotal.ToString("f2");

        //        if (taxableCheckBox.Checked)
        //            tax = Decimal.Round((newSubtotal) * 0.06m, 2);
        //        else
        //            tax = 0;
        //        taxTextBox.Text = tax.ToString("f2");

        //        total = newSubtotal + tax + nudShipping.Value;
        //        totalTextBox.Text = total.ToString("f2");

        //        if (newOrder)
        //        {
        //            if (cbPaidFull.Checked)
        //                nudAmountPaid.Value = total;
        //        }

        //        if (nudAmountPaid.Value >= total)
        //        {
        //            txtAmountDue.Text = "0.00";
        //        }
        //        else
        //            txtAmountDue.Text = (total - nudAmountPaid.Value).ToString("f2");
        //        lblLeftOverCredit.Text = leftoverCredit.ToString("f2");
        //}

    }
}
