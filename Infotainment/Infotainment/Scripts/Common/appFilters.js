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

                result.push({ FirstColumn: firstCol[rowCounter], SecondColumn: secondColVal });
            };

            return result;
        };
    });