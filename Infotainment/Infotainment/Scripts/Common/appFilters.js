angular.module('infotainment')
    .filter('sorting', function () {
        return function (items, field, reverse) {
            var filtered = [];
            var dashRows = [];
            var industries = [];
            var result = [];
            var indisutryName = null;

            angular.forEach(items, function (item) {
                if (item['IsIndustry']) {
                    industryName = item['IndustryName'];
                    industries[industryName] = item;
                    dashRows.push({ Industry: industryName, rows: [] });
                    filtered.push({ Industry: industryName, rows: [] });
                }

                if (!item['IsIndustry']) {
                    switch (item[field]) {
                        case null:
                        case '-':
                            if (industryName != null)
                                dashRows[dashRows.length - 1].rows.push(item);
                            break;
                        default:
                            if (industryName != null)
                                filtered[filtered.length - 1].rows.push(item);
                            break;
                    }
                }

            });


            var IsInt = /^\d+$/;
            var Isfloat = /^[+-]?(\.\d+)|(\d+(\.\d+)?)$/;

            if (filtered.length > 0) {
                angular.forEach(filtered, function (subset) {
                    subset.rows.sort(function (a, b) {
                        if (IsInt.test(a[field]) && IsInt.test(b[field])) {
                            return (Number(a[field]) > Number(b[field]) ? 1 : -1);
                        }
                        else if (Isfloat.test(a[field]) && Isfloat.test(b[field])) {
                            return (Number(a[field]) > Number(b[field]) ? 1 : -1);
                        }
                        else {
                            return (a[field] > b[field] ? 1 : -1);
                        }
                    });
                });
            }

            if (reverse) {
                angular.forEach(filtered, function (subset) {
                    subset.rows.reverse();
                });
            }

            if (dashRows.length > 0) {
                angular.forEach(dashRows, function (dashsubset) {
                    for (var i = 0; i < filtered.length ; i++) {
                        if (dashsubset.Industry == filtered[i].Industry) {
                            angular.forEach(dashsubset.rows, function (row) {
                                filtered[i].rows.push(row);
                            });
                        }
                    }
                });
            }



            angular.forEach(filtered, function (subset) {
                if (industries[subset.Industry] != undefined)
                    result = result.concat(industries[subset.Industry]);
                angular.forEach(subset.rows, function (row) {
                    result = result.concat(row);
                });
            });

            return result;
        };
    })
    .filter('multifieldsort', function () {
        return function (items, field1, field2, reverse) {
            var sortedRow = [];
            var dashRows = [];
            var undefinedRow = [];

            if (field1 == undefined && field1 == null)
                return result;

            if (field2 == undefined && field2 == null)
                return result;

            angular.forEach(items, function (item) {
                switch (item[field1]) {
                    case null:
                    case "":
                    case '-':
                        dashRows.push(item);
                        break;
                    case undefined:
                        undefinedRow.push(item);
                        break;
                    default:
                        sortedRow.push(item);
                        break;
                }
            });

            var IsInt = /^\d+$/;
            var Isfloat = /^[+-]?(\.\d+)|(\d+(\.\d+)?)$/;

            if (sortedRow.length > 0) {
                sortedRow.sort(function (a, b) {
                    if ((IsInt.test(a[field1]) && IsInt.test(b[field1])) || (Isfloat.test(a[field1]) && Isfloat.test(b[field1]))) {
                        if (Number(a[field1]) > Number(b[field1])) {
                            return 1;
                        }
                        else if (Number(a[field1]) === Number(b[field1])) {
                            if (a[field2] != undefined && b[field2] != undefined) {
                                if ((IsInt.test(a[field2]) && IsInt.test(b[field2])) || (Isfloat.test(a[field2]) && Isfloat.test(b[field2]))) {
                                    return (Number(a[field2]) > Number(b[field2])) ? 1 : -1;
                                }
                            }
                        }

                        return -1;

                    }
                    else {
                        if (Number(a[field1]).toString().toLowerCase() > Number(b[field1]).toString().toLowerCase()) {
                            return 1;
                        }
                        else if (Number(a[field1]).toString().toLowerCase() === Number(b[field1]).toString().toLowerCase()) {
                            if (a[field2] != undefined && b[field2] != undefined) {
                                if ((IsInt.test(a[field2]) && IsInt.test(b[field2])) || (Isfloat.test(a[field2]) && Isfloat.test(b[field2]))) {
                                    return (Number(a[field2]) > Number(b[field2])) ? 1 : -1;
                                }
                            }
                        }

                        return -1;
                    }
                });
            }

            if (reverse) {
                sortedRow.reverse();
            }

            if (dashRows.length > 0) {
                angular.forEach(dashRows, function (row) {
                    sortedRow.push(row);
                });
            }

            if (undefinedRow.length > 0) {
                angular.forEach(undefinedRow, function (row) {
                    sortedRow.push(row);
                });
            }

            return sortedRow;
        };
    })
    .filter('number', function () {
        return function (input, roundingVal) {
            if (input == null || input == 0 || input == 0.0 || input == "-" || input == undefined)
                return '-';

            var result = parseFloat(input)
            if (roundingVal >= 0) {
                result = result.toFixed(roundingVal);
            }

            return result;
        };
    })
    .filter('mathRound', function () {
        return function (input) {

            if (input == null || input == undefined || input == "-") {
                return '-';
            }

            return Math.round(parseFloat(input));
        };
    })
    .filter('currencyFilter', function ($filter) {
        return function (input, currencycode, precision) {

            if (input == undefined) return '';

            if (currencycode == null) currencycode = '';
            if (precision == null) precision = 0;

            if (angular.isNumber(input))
                var value = input;
            else {
                if (input.indexOf(',') > -1)
                    var value = parseFloat(input.replace(',', ''));
                else
                    var value = parseFloat(input);
            }
            if (currencycode.length > 1)
                currencycode += ' ';
            if (value < 0) { //negative value
                var output = $filter('currency')(value, '', precision);
                return currencycode + output.replace("(", "-").replace(")", "");
            }
            else {
                return $filter('currency')(value, currencycode, precision);
            }
        }
    })
    .filter('stringFormat', function () {
        function toFormattedString(useLocale, format, values) {
            var result = '';

            for (var i = 0; ;) {
                // Find the next opening or closing brace
                var open = format.indexOf('{', i);
                var close = format.indexOf('}', i);
                if ((open < 0) && (close < 0)) {
                    // Not found: copy the end of the string and break
                    result += format.slice(i);
                    break;
                }
                if ((close > 0) && ((close < open) || (open < 0))) {

                    if (format.charAt(close + 1) !== '}') {
                        throw new Error('format stringFormatBraceMismatch');
                    }

                    result += format.slice(i, close + 1);
                    i = close + 2;
                    continue;
                }

                // Copy the string before the brace
                result += format.slice(i, open);
                i = open + 1;

                // Check for double braces (which display as one and are not arguments)
                if (format.charAt(i) === '{') {
                    result += '{';
                    i++;
                    continue;
                }

                if (close < 0) throw new Error('format stringFormatBraceMismatch');

                // Find the closing brace

                // Get the string between the braces, and split it around the ':' (if any)
                var brace = format.substring(i, close);
                var colonIndex = brace.indexOf(':');
                var argNumber = parseInt((colonIndex < 0) ? brace : brace.substring(0, colonIndex), 10);

                if (isNaN(argNumber)) throw new Error('format stringFormatInvalid');

                var argFormat = (colonIndex < 0) ? '' : brace.substring(colonIndex + 1);

                var arg = values[argNumber];
                if (typeof (arg) === "undefined" || arg === null) {
                    arg = '';
                }

                // If it has a toFormattedString method, call it.  Otherwise, call toString()
                if (arg.toFormattedString) {
                    result += arg.toFormattedString(argFormat);
                } else if (useLocale && arg.localeFormat) {
                    result += arg.localeFormat(argFormat);
                } else if (arg.format) {
                    result += arg.format(argFormat);
                } else
                    result += arg.toString();

                i = close + 1;
            }

            return result;
        };

        return function (/*string*/template, /*array*/values) {
            if (!values || !values.length || !template) {
                return template;
            }
            return toFormattedString(false, template, values);
        };
    })
    .filter('SingleToDoubleRow', function () {
        return function (rows) {
            var firstCol = [];
            var secondCol = [];
            var result = [];

            var colDivider = rows.length % 2 == 0 ? (rows.length / 2) : (Math.round(rows.length / 2));

            var counter = 1;
            angular.forEach(rows, function (row) {
                if (counter <= colDivider)
                    firstCol.push(row);
                else
                    secondCol.push(row);

                counter++;
            });

            for (var rowCounter = 0; rowCounter < firstCol.length; rowCounter++) {
                var secondColVal = "";
                if (secondCol.length - 1 >= rowCounter)
                    secondColVal = secondCol[rowCounter];

                result.push({ FirstCellValue: firstCol[rowCounter], SecondCellValue: secondColVal });
            };

            return result;
        };
    })
    .filter('topRows', function () {
        return function (rows, topRowlength) {
            var counter = 0;
            var result = [];

            angular.forEach(rows, function (row) {
                if (counter < topRowlength)
                    result.push(row);

                counter++;
            });

            return result;
        };
    })
    .filter('restRows', function () {
        return function (rows, topRowlength) {
            var result = [];
            for (var counter = topRowlength; counter < rows.length; counter++) {
                result.push(rows[counter]);
            }

            return result;
        };
    })
    .filter('daterange', function () {
        return function (data, start_date, end_date) {
            var result = [];

            // date filters
            var start_date = start_date ? Date.parse(start_date) : 0;
            var end_date = end_date ? Date.parse(end_date) : new Date().getTime();

            //start_date = formatDate(start_date);
            //end_date = formatDate(end_date);

            // if the conversations are loaded
            if (data && data.length > 0) {
                angular.forEach(data, function (row) {
                    var itemDate = Date.parse(row.LastInvestmentDate);
                    if (itemDate >= start_date && itemDate <= end_date) {
                        result.push(row);
                    }
                });

                return result;
            }
        };
    })
    .filter('compute', function () {
        function addition(rows, ColumnName) {
            var sum = 0.00;
            angular.forEach(rows, function (row) {
                if (row[ColumnName] != undefined && row[ColumnName] != null && row[ColumnName] != Constants.EmptyCellValue)
                    sum = parseFloat(sum) + parseFloat(row[ColumnName]);
            });

            return sum;
        }
        return function (rows, columnName, operation) {

            switch (operation) {
                case "sum":
                    return addition(rows, columnName);
            }


            return result;
        };
    })
    .filter('utcformatteddate', function ($filter, preferences) {
        return function dateFormatter(value, format) {
            format = format || preferences.dateFormat;

            var date = new Date(value);
            date = new Date(date.getTime());
            date.setMinutes(date.getMinutes() + date.getTimezoneOffset());

            return $filter('date')(date, format);
        }
       
    })
    .filter('hindiDate', function () {
        return function (d) {
            var date = new Date(d);
            var weekday = new Array(7);
            weekday[0] = "रविवार";
            weekday[1] = "सोमवार";
            weekday[2] = "मंगलवार";
            weekday[3] = "बुधवार";
            weekday[4] = "गुरुवार";
            weekday[5] = "शुक्रवार";
            weekday[6] = "शनिवार";

            var day = weekday[date.getDay()];

            var month = new Array();
            month[0] = "जनवरी";
            month[1] = "फ़रवरी";
            month[2] = "मार्च";
            month[3] = "अप्रैल";
            month[4] = "मई";
            month[5] = "जून";
            month[6] = "जुलाई";
            month[7] = "आगस्त";
            month[8] = "सितम्बर";
            month[9] = "अकतूबर";
            month[10] = "नवेम्बर";
            month[11] = "दिसम्बर";
            var mon = month[date.getMonth()];

            return day + ", " + date.getDate() + " " + mon + " " + date.getFullYear() + " " + date.getHours() + ":" + date.getMinutes();
        };
    });
