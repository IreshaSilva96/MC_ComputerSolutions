import React, { useState, useEffect } from "react";
import Dialog from "@material-ui/core/Dialog";

const InvoiceData = ({ selectedInvoiceNo, ...props }) => {
  console.log(selectedInvoiceNo);
  const [refresh, setRefresh] = useState(false);
  const [customerName, setCustomerName] = useState([]);
  const [purchasedDate, setPurchasedDate] = useState([]);
  const [grossTotal, setGrossTotal] = useState([]);
  const [discount, setDiscount] = useState([]);
  const [netTotal, setNetTotal] = useState([]);

  const [productData, setProductData] = useState([]);
  const [invoiceNo, setInvoiceNo] = useState([]);

  var invoice = 233010;
  //Fetch Data
  useEffect(() => {
    fetch(
      `https://localhost:44384/api/Invoice/byInvoiceNo/${selectedInvoiceNo}`
    )
      .then((res) => res.json())
      .then((data) => {
        console.log("data" + data);
        setCustomerName(data.customerName);
        setInvoiceNo(data.invoiceNo);
        setPurchasedDate(data.purchasedDate);
        setGrossTotal(data.grossTotal);
        setNetTotal(data.netTotal);
        setDiscount(data.discount);
      });
  }, [refresh]);

  useEffect(() => {
    fetch(
      `https://localhost:44384/api/InvoiceProducts/byInvoiceNo/${selectedInvoiceNo}`
    )
      .then((res) => res.json())
      .then((data) => {
        setProductData(data);
      });
  }, []);

  return (
    <div>
      <div align="center">
        <div className="invoiceMainDiv" align="center">
          <p className="heading">VIEW INVOICE </p>
          <div class="row" align="center">
            <div class="column">
              <div className="form">
                <label className="formLabel">Invoice No.</label>
                <span className="formSpan">
                  <input
                    className="formInput"
                    id="invoiceNo"
                    name="invoiceNo"
                    type="text"
                    placeholder="Invoice No."
                    value={invoiceNo}
                  />
                </span>
              </div>
            </div>
            <div class="column">
              <div className="form">
                <label className="formLabel">Customer Name</label>
                <span className="formSpan">
                  <input
                    className="formInput"
                    id="customerName"
                    name="customerName"
                    type="text"
                    placeholder="Customer Name"
                    value={customerName}
                  />
                </span>
              </div>
            </div>
            <div class="column">
              <div className="form">
                <label className="formLabel">Date</label>
                <span className="formSpan">
                  <input
                    className="formInput"
                    id="date"
                    name="date"
                    type="text"
                    placeholder="Date"
                    value={purchasedDate}
                  />
                </span>
              </div>
            </div>
          </div>
          <table className="tableData">
            <thead>
              <th>Product Name</th>
              <th>Unit Price</th>
              <th>Quantity</th>
              <th>Total</th>
            </thead>
            <tbody>
              {productData.map((data) => (
                <tr>
                  <td>
                    {data.productID} - {data.productName}
                  </td>
                  <td>{Number(data.unitPrice).toFixed(2)}</td>
                  <td>{data.quantity}</td>
                  <td>{Number(data.total).toFixed(2)}</td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td></td>
                <td>GrossTotal</td>
                <td>{grossTotal}</td>
              </tr>
              <tr>
                <td></td>
                <td>Discount</td>
                <td>{discount}</td>
              </tr>
              <tr>
                <td></td>
                <td>Total</td>
                <td>{netTotal}</td>
              </tr>
            </tfoot>
          </table>
          <br />
        </div>
      </div>
    </div>
  );
};

export default InvoiceData;
