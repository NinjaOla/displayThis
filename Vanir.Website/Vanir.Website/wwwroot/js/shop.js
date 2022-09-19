(function () {
  var scriptURL = 'https://sdks.shopifycdn.com/buy-button/latest/buy-button-storefront.min.js';
  if (window.ShopifyBuy) {
    if (window.ShopifyBuy.UI) {
      ShopifyBuyInit();
    } else {
      loadScript();
    }
  } else {
    loadScript();
  }

  function loadScript() {
    var script = document.createElement('script');
    script.async = true;
    script.src = scriptURL;
    (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(script);
    script.onload = ShopifyBuyInit;
  }
  function ShopifyBuyInit() {
    var client = ShopifyBuy.buildClient({
      domain: 'esport-brands.myshopify.com',
      storefrontAccessToken: '5962468b6dcb32380b55bb549a8fb87c',
    });
      ShopifyBuy.UI.onReady(client).then(function (ui) {
          ui.createComponent('collection', {
              id: '289314898119',
              node: document.getElementById('collection-component-1656931334858'),
              moneyFormat: '%7B%7Bamount_with_comma_separator%7D%7D%20kr',
              options: {
                  "product": {
                      "styles": {
                          "product": {
                              "@media (min-width: 601px)": {
                                  "max-width": "calc(50% - 40px)",
                                  "margin-left": "40px",
                                  "margin-bottom": "50px",
                                  "width": "calc(50% - 40px)"
                              }
                          },
                          "button": {
                              ":hover": {
                                  "background-color": "#000000"
                              },
                              "background-color": "#000000",
                              ":focus": {
                                  "background-color": "#000000"
                              }
                          }
                      },
                      "buttonDestination": "modal",
                      "contents": {
                          "options": false
                      },
                      "text": {
                          "button": "View product"
                      }
                  },
                  "productSet": {
                      "styles": {
                          "products": {
                              "@media (min-width: 601px)": {
                                  "margin-left": "-40px"
                              }
                          }
                      }
                  },
                  "modalProduct": {
                      "contents": {
                          "img": false,
                          "imgWithCarousel": true,
                          "button": false,
                          "buttonWithQuantity": true
                      },
                      "styles": {
                          "product": {
                              "@media (min-width: 601px)": {
                                  "max-width": "100%",
                                  "margin-left": "0px",
                                  "margin-bottom": "0px"
                              }
                          },
                          "button": {
                              ":hover": {
                                  "background-color": "#000000"
                              },
                              "background-color": "#000000",
                              ":focus": {
                                  "background-color": "#000000"
                              }
                          }
                      },
                      "text": {
                          "button": "Add to cart"
                      }
                  },
                  "option": {},
                  "cart": {
                      "styles": {
                          "button": {
                              ":hover": {
                                  "background-color": "#000000"
                              },
                              "background-color": "#000000",
                              ":focus": {
                                  "background-color": "#000000"
                              }
                          }
                      },
                      "text": {
                          "total": "Subtotal",
                          "empty": "Your shopping cart is empty.",
                          "notice": "Shipping and discount codes are added to the checkout.",
                          "button": "Checkout"
                      }
                  },
                  "toggle": {
                      "styles": {
                          "toggle": {
                              "background-color": "#000000",
                              ":hover": {
                                  "background-color": "#000000"
                              },
                              ":focus": {
                                  "background-color": "#000000"
                              }
                          }
                      }
                  }
              },
          });
      }).then(function () {
          document.getElementById("loader").remove();
      });
  }
})();