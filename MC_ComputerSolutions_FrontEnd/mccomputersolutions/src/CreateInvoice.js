import React, { useState, useEffect } from "react";
import Dialog from "@material-ui/core/Dialog";

const CreateInvoice = ({ modalOpen, ...props }) => {
  const { open, setOpen } = props;
  const [refresh, setRefresh] = useState(false);
  const [customerName, setCustomerName] = useState([]);
  const [purchasedDate, setPurchasedDate] = useState([]);
  const [grossTotal, setGrossTotal] = useState([]);
  const [discount, setDiscount] = useState([]);
  const [netTotal, setNetTotal] = useState([]);

  const [productData, setProductData] = useState([]);
  const [productID, setProductID] = useState([]);
  const [invoiceNo, setInvoiceNo] = useState("");

  const [load, setLoad] = useState(false);

  var today = new Date();

  var date =
    today.getDate() + "." + today.getMonth() + "." + today.getFullYear();

  var time =
    today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();

  const CreateInvoice = (e) => {
    fetch(`https://localhost:44384/api/Invoice`, {
      method: "POST",
      headers: {
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        invoiceNo: invoiceNo,
        customerName: customerName,
        purchasedDate: new Date(),
        grossTotal: parseFloat("0"),
        discount: parseFloat("0"),
        netTotal: parseFloat("0"),
      }),
    }).then((data) => {
      console.log(data);
      setRefresh(refresh === false ? true : false);
    });
  };

  const [invoiceData, setInvoiceData] = useState([]);

  useEffect(() => {
    fetch("https://localhost:44384/api/Invoice")
      .then((res) => res.json())
      .then((data) => {
        setInvoiceData(data);
      });
  }, []);

  const [unitPrice, setUnitPrice] = useState([]);

  useEffect(() => {
    fetch("https://localhost:44384/api/Product")
      .then((res) => res.json())
      .then((data) => {
        setProductData(data);
      });
  }, []);

  useEffect(() => {
    fetch(`https://localhost:44384/api/Product/${productID}`)
      .then((res) => res.json())
      .then((data) => {
        setUnitPrice(data.unitPrice);
        setQuantity("1");
        setTotal("0");
      });
  }, [productID]);

  const [quantity, setQuantity] = useState([]);
  const [total, setTotal] = useState([]);

  const CreateInvoiceProducts = (e) => {
    fetch(`https://localhost:44384/api/InvoiceProducts`, {
      method: "POST",
      headers: {
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        invoiceNo: invoiceNo,
        productID: parseInt(productID),
        quantity: parseInt(quantity),
        total: parseFloat(unitPrice * quantity),
      }),
    })
      .then((res) => {
        if (res.status === 200) {
          setRefresh(refresh === false ? true : false);
          return [];
        } else {
          res.json();
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  const [invoiceProductsList, setInvoiceProductsList] = useState([]);

  var currentInvoiceID = 7;

  const [rowProductID, setRowProductID] = useState([]);

  useEffect(() => {
    // debugger;
    if (invoiceNo !== "") {
      console.log("invoiceNo: " + invoiceNo);
      fetch(
        `https://localhost:44384/api/InvoiceProducts/byInvoiceNo/${invoiceNo}`
      )
        .then((res) => res.json())
        .then((data) => {
          setInvoiceProductsList(data);
          setRowProductID(data.productID);
        });
    } else {
      console.log("empty");
    }
  }, [refresh]);

  if (rowProductID == undefined) {
    setRowProductID(2141221010);
  }

  const [selectedInvoiceProductID, setSelectedInvoiceProductID] = useState("");

  console.log("selectedInvoiceProductID: " + selectedInvoiceProductID);

  if (selectedInvoiceProductID == undefined) {
    setSelectedInvoiceProductID(2141221010);
  }

  const DeleteProduct = () => {
    fetch(
      `https://localhost:44384/api/InvoiceProducts/${selectedInvoiceProductID}`,
      {
        method: "DELETE",
      }
    )
      .then((res) => {
        if (res.status === 200) {
          setRefresh(refresh === false ? true : false);
          return [];
        } else {
          res.json();
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  //Reset Data
  const handleClear = (e) => {
    setProductID(null);
    setUnitPrice("0");
    setQuantity("0");
    setTotal("0");
  };

  var GrossTotal = invoiceProductsList.reduce((a, v) => (a = a + v.total), 0);
  var NetTotal = GrossTotal * ((100 - discount) / 100);

  const UpdateInvoice = (e) => {
    fetch(`https://localhost:44384/api/Invoice/${invoiceNo}`, {
      method: "PUT",
      headers: {
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        invoiceNo: invoiceNo,
        customerName: customerName,
        purchasedDate: "2022-05-12T20:59:59",
        grossTotal: parseFloat(GrossTotal),
        discount: parseFloat(discount),
        netTotal: parseFloat(NetTotal),
      }),
    })
      .then((res) => {
        if (res.status === 200) {
          setRefresh(refresh === false ? true : false);
          return [];
        } else {
          res.json();
        }
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <div open={open}>
      <div align="center">
        <div className="invoiceMainDiv" align="center">
          <p className="heading">CREATE INVOICE</p>
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
                    onChange={(e) => {
                      setInvoiceNo(e.target.value);
                    }}
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
                    onChange={(e) => {
                      setCustomerName(e.target.value);
                    }}
                  />
                </span>
              </div>
            </div>
            <div class="column">
              <div
                class="col_Buttons"
                align="center"
                style={{ marginTop: "20px" }}
              >
                <button
                  className="Buttons"
                  onClick={() => {
                    CreateInvoice();
                    console.log(customerName);
                    setLoad(true);
                  }}
                >
                  Proceed
                </button>
              </div>
            </div>
          </div>
          {load === true && (
            <>
              <table className="tableData">
                <thead>
                  <th>Product Name</th>
                  <th>Unit Price</th>
                  <th>Quantity</th>
                  <th>Total</th>
                  <th>Action</th>
                </thead>
                <tbody>
                  <tr className="dataAddRow">
                    <td>
                      <span className="formSpan">
                        <select
                          className="formInput"
                          id="sizeID"
                          name="sizeID"
                          placeholder="size"
                          value={productID}
                          onChange={(e) => {
                            setProductID(e.target.value);
                          }}
                        >
                          <option selected value="null" className="selectNull">
                            Select Product
                          </option>
                          {productData.map((product) => (
                            <option value={product.productID}>
                              {product.productID} - {product.productName}{" "}
                            </option>
                          ))}
                        </select>
                      </span>
                    </td>
                    <td>
                      <span className="formSpan">
                        <input
                          className="formInput"
                          id="unitPrice"
                          name="unitPrice"
                          type="text"
                          placeholder="Unit Price"
                          disabled="true"
                          value={Number(unitPrice).toFixed(2)}
                        />
                      </span>
                    </td>
                    <td>
                      <input
                        className="formInput"
                        id="quantity"
                        name="quantity"
                        type="number"
                        min="1"
                        placeholder="Quantity"
                        value={quantity}
                        onChange={(e) => {
                          setQuantity(e.target.value);
                        }}
                      />
                    </td>
                    <td>
                      <span className="formSpan">
                        <input
                          className="formInput"
                          id="total"
                          name="total"
                          type="text"
                          placeholder="Total"
                          disabled="true"
                          value={
                            isNaN(unitPrice * quantity)
                              ? 0
                              : Number(unitPrice * quantity).toFixed(2)
                          }
                        />
                      </span>
                    </td>
                    <td>
                      <button
                        className="Buttons"
                        onClick={() => {
                          CreateInvoiceProducts();
                          handleClear();
                          setRefresh(true);
                        }}
                      >
                        ADD
                      </button>
                    </td>
                  </tr>
                  {invoiceProductsList.map((data) => (
                    <tr
                      onClick={() =>
                        setSelectedInvoiceProductID(data.invoiceProductID)
                      }
                    >
                      <td>
                        {data.productID} - {data.productName}
                      </td>
                      <td>{Number(data.unitPrice).toFixed(2)}</td>
                      <td>{data.quantity}</td>
                      <td>{Number(data.total).toFixed(2)}</td>
                      <td>
                        <button
                          onClick={() => {
                            DeleteProduct();
                          }}
                        >
                          X
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
                <tfoot>
                  <tr>
                    <td></td>
                    <td>GrossTotal</td>
                    <td>{Number(GrossTotal).toFixed(2)}</td>
                  </tr>
                  <tr>
                    <td></td>
                    <td>Discount</td>
                    <td>
                      <input
                        className="formInput"
                        id="discount"
                        name="discount"
                        type="number"
                        min="1"
                        placeholder="Discount %"
                        value={discount}
                        onChange={(e) => {
                          setDiscount(e.target.value);
                        }}
                      />
                    </td>
                  </tr>
                  <tr>
                    <td></td>
                    <td>Total</td>
                    <td>{Number(NetTotal).toFixed(2)}</td>
                  </tr>
                </tfoot>
              </table>
              <div class="col_Buttons" align="left">
                <button
                  className="Buttons"
                  onClick={() => {
                    UpdateInvoice();
                    modalOpen(false);
                  }}
                >
                  SAVE EXIT
                </button>
              </div>
            </>
          )}
        </div>
      </div>
    </div>
  );
};

export default CreateInvoice;
