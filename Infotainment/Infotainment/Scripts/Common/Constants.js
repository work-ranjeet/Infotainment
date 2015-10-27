Constants = {
    Empty: "",
    EmptyCellValue: "-",
    NullValue: null,
    DateFormat: "dd-MMM-yyyy"
};

FieldType = {
    EmptyCell: "",
    Label: "label",
    Data: "data"
};

DataType = {
    String: "string"
}

DataFormat = {
    Url: "url",
    Text: "text",
    Percent: "percent",
    PercentChange: "percentChange",
    Money: "money",
    Address: "address",
    MoreText: "more",
    Date: "date",
    Function: "function",
    Json: "json"
};


RegEmail = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
RegMob = /^\d{10}$/;