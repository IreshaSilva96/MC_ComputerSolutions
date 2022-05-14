// import React, { useState, useEffect } from "react";

// import NoSearchFound from "./Images/NoSearchFound.gif";
// import "./App.css";

// import Modal from "./Modal";

// export default function App(props) {
//   const [listData, setListData] = useState([]);
//   const [refresh, setRefresh] = useState(false);

//   const [search, setSearch] = useState(null);
//   const [id, setId] = useState([]);
//   const [selectedRowData, setSelectedRowData] = useState([]);

//   const [invoiceID, setInvoiceID] = useState([]);
//   const [customerName, setCustomerName] = useState([]);
//   const [purchasedDate, setPurchasedDate] = useState([]);
//   const [grossTotal, setGrossTotal] = useState([]);
//   const [discount, setDiscount] = useState([]);
//   const [netTotal, setNetTotal] = useState([]);

//   const [modalOpen, setModalOpen] = useState(false);
//   const [create, setCreate] = useState(false);
//   const [view, setView] = useState(false);

//   //Fetch Data
//   useEffect(() => {
//     fetch("https://localhost:44384/api/Invoice")
//       .then((res) => res.json())
//       .then((data) => {
//         setListData(data);
//         //console.log(listData);
//       });
//   }, [refresh]);

//   //Search
//   const bySearch = (data, search) => {
//     if (search) {
//       return data.customerName.toLowerCase().includes(search.toLowerCase());
//     } else return data;
//   };

//   const filteredList = (listData, search) => {
//     return listData.filter((data) => bySearch(data, search));
//   };

//   //Fetch Row Data
//   useEffect(() => {
//     fetch(`https://localhost:44384/api/Invoice/${id}`)
//       .then((res) => res.json())
//       .then((data) => {
//         setSelectedRowData(data);
//         setInvoiceID(data.invoiceID);
//         setCustomerName(data.customerName);
//         setPurchasedDate(data.purchasedDate);
//         setGrossTotal(data.grossTotal);
//         setDiscount(data.discount);
//         setNetTotal(data.netTotal);
//       });
//   }, [id, refresh]);

//   return (
//     <>
//       <div align="center">
//         <div className="searchTable">
//           <div class="col_Buttons" style={{ width: "100%" }}>
//             <button
//               className="Buttons"
//               onClick={() => {
//                 setView(false);
//                 setCreate(true);
//               }}
//             >
//               CREATE
//             </button>
//             <button
//               className="Buttons"
//               onClick={() => {
//                 setView(true);
//                 setCreate(false);
//               }}
//             >
//               VIEW
//             </button>
//           </div>
//         </div>
//         {view == true && (
//           <>
//             <div class="searchButton">
//               <input
//                 type="text"
//                 class="searchTerm"
//                 placeholder="SEARCH"
//                 onChange={(e) => setSearch(e.target.value)}
//               />
//               <div className="searchIcon">
//                 <svg
//                   xmlns="http://www.w3.org/2000/svg"
//                   width="40"
//                   height="40"
//                   viewBox="0 0 45.386 45.386"
//                 >
//                   <g id="magnifier" transform="translate(-0.001 0)">
//                     <g
//                       id="Group_1271"
//                       data-name="Group 1271"
//                       transform="translate(0.001 0)"
//                     >
//                       <path
//                         id="Path_1465"
//                         data-name="Path 1465"
//                         d="M40,31.43A18.416,18.416,0,0,0,13.957,5.385a18.058,18.058,0,0,0-2.77,22.226.775.775,0,0,1-.107.923l-9.4,9.4c-1.87,1.87-2.315,4.485-.657,6.144l.286.285c1.658,1.659,4.274,1.214,6.144-.656l9.376-9.376a.786.786,0,0,1,.943-.127A18.058,18.058,0,0,0,40,31.43Zm-22.644-3.4a13.608,13.608,0,1,1,19.244,0A13.623,13.623,0,0,1,17.357,28.03Z"
//                         transform="translate(-0.001 0)"
//                         fill="#ff4f5b"
//                       />
//                       <g
//                         id="Group_1270"
//                         data-name="Group 1270"
//                         transform="translate(16.632 7.37)"
//                       >
//                         <path
//                           id="Path_1466"
//                           data-name="Path 1466"
//                           d="M115.652,60.353a1.9,1.9,0,0,1-1.75-2.642,11.979,11.979,0,0,1,15.683-6.357,1.9,1.9,0,1,1-1.482,3.5,8.173,8.173,0,0,0-10.7,4.337A1.9,1.9,0,0,1,115.652,60.353Z"
//                           transform="translate(-113.752 -50.409)"
//                           fill="#ff4f5b"
//                         />
//                       </g>
//                     </g>
//                   </g>
//                 </svg>
//               </div>
//             </div>
//             <table className="tableData">
//               <thead>
//                 <th>Invoice</th>
//                 <th>Customer Name</th>
//                 <th>Purchased Date</th>
//                 <th>Gross Total</th>
//                 <th>Discount</th>
//                 <th>Net Total</th>
//                 <th>View</th>
//               </thead>
//               <tbody>
//                 {filteredList(listData, search).map((data) => (
//                   <tr onClick={() => setId(data.sizeID)}>
//                     <td>{data.invoiceID}</td>
//                     <td>{data.customerName}</td>
//                     <td>{data.purchasedDate}</td>
//                     <td>{data.grossTotal}</td>
//                     <td>{data.discount}</td>
//                     <td>{data.netTotal}</td>
//                     <td>
//                       <button>view</button>
//                     </td>
//                   </tr>
//                 ))}

//                 {filteredList(listData, search).length === 0 && (
//                   <div className="NoSearchFoundDIV" align="center">
//                     <img src={NoSearchFound} className="NoSearchFoundGIF" />
//                     <br />
//                     <b>NO RESULT FOUND</b>
//                     <br />
//                     <br />
//                     We couldn't find any match for '{search}',
//                     <br /> Please try another search.
//                   </div>
//                 )}
//               </tbody>
//             </table>
//           </>
//         )}
//       </div>
//       {create == true && view == false && (
//         <Modal open={modalOpen} setOpen={setModalOpen} />
//       )}
//     </>
//   );
// }
