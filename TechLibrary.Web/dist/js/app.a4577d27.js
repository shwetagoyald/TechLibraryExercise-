(function(t){function e(e){for(var n,s,i=e[0],u=e[1],c=e[2],l=0,d=[];l<i.length;l++)s=i[l],Object.prototype.hasOwnProperty.call(o,s)&&o[s]&&d.push(o[s][0]),o[s]=0;for(n in u)Object.prototype.hasOwnProperty.call(u,n)&&(t[n]=u[n]);f&&f(e);while(d.length)d.shift()();return a.push.apply(a,c||[]),r()}function r(){for(var t,e=0;e<a.length;e++){for(var r=a[e],n=!0,s=1;s<r.length;s++){var u=r[s];0!==o[u]&&(n=!1)}n&&(a.splice(e--,1),t=i(i.s=r[0]))}return t}var n={},o={app:0},a=[];function s(t){return i.p+"js/"+({Book:"Book"}[t]||t)+"."+{Book:"ff248c1a"}[t]+".js"}function i(e){if(n[e])return n[e].exports;var r=n[e]={i:e,l:!1,exports:{}};return t[e].call(r.exports,r,r.exports,i),r.l=!0,r.exports}i.e=function(t){var e=[],r=o[t];if(0!==r)if(r)e.push(r[2]);else{var n=new Promise((function(e,n){r=o[t]=[e,n]}));e.push(r[2]=n);var a,u=document.createElement("script");u.charset="utf-8",u.timeout=120,i.nc&&u.setAttribute("nonce",i.nc),u.src=s(t);var c=new Error;a=function(e){u.onerror=u.onload=null,clearTimeout(l);var r=o[t];if(0!==r){if(r){var n=e&&("load"===e.type?"missing":e.type),a=e&&e.target&&e.target.src;c.message="Loading chunk "+t+" failed.\n("+n+": "+a+")",c.name="ChunkLoadError",c.type=n,c.request=a,r[1](c)}o[t]=void 0}};var l=setTimeout((function(){a({type:"timeout",target:u})}),12e4);u.onerror=u.onload=a,document.head.appendChild(u)}return Promise.all(e)},i.m=t,i.c=n,i.d=function(t,e,r){i.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:r})},i.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},i.t=function(t,e){if(1&e&&(t=i(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var r=Object.create(null);if(i.r(r),Object.defineProperty(r,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var n in t)i.d(r,n,function(e){return t[e]}.bind(null,n));return r},i.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return i.d(e,"a",e),e},i.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},i.p="/",i.oe=function(t){throw console.error(t),t};var u=window["webpackJsonp"]=window["webpackJsonp"]||[],c=u.push.bind(u);u.push=e,u=u.slice();for(var l=0;l<u.length;l++)e(u[l]);var f=c;a.push([0,"chunk-vendors"]),r()})({0:function(t,e,r){t.exports=r("56d7")},"56d7":function(t,e,r){"use strict";r.r(e);r("e260"),r("e6cf"),r("cca6"),r("a79d");var n=r("2b0e"),o=function(){var t=this,e=t.$createElement,r=t._self._c||e;return r("div",{attrs:{id:"app"}},[r("b-container",[r("router-view")],1)],1)},a=[],s=r("57da"),i={name:"app",components:{Home:s["default"]}},u=i,c=r("2877"),l=Object(c["a"])(u,o,a,!1,null,null,null),f=l.exports,d=r("5f5b"),p=r("b1e0"),h=(r("f9e3"),r("2dd8"),r("d3b7"),r("8c4f"));n["default"].use(h["a"]);var v=function(){return Promise.resolve().then(r.bind(null,"57da"))},b=function(){return r.e("Book").then(r.bind(null,"c71c"))},m=function(){return r.e("Book").then(r.bind(null,"2bbd"))},g=new h["a"]({routes:[{path:"/",component:v},{name:"book_view",path:"/book/:id",component:b,props:!0},{name:"book_add",path:"/add",component:m,props:!0}]}),k=g;n["default"].use(d["a"]),n["default"].use(p["a"]),n["default"].config.productionTip=!1,new n["default"]({router:k,render:function(t){return t(f)}}).$mount("#app")},"57da":function(t,e,r){"use strict";r.r(e);var n=function(){var t=this,e=t.$createElement,r=t._self._c||e;return r("div",{staticClass:"home"},[r("h1",[t._v(t._s(t.msg))]),r("b-form-input",{attrs:{type:"text",placeholder:"Search By Title or Description"},on:{keyup:function(e){return!e.type.indexOf("key")&&t._k(e.keyCode,"enter",13,e.key,"Enter")?null:t.getFilteredBooksData(e)}},model:{value:t.searchText,callback:function(e){t.searchText=e},expression:"searchText"}}),r("br"),r("b-link",{attrs:{variant:"primary",to:{name:"book_add"}}},[t._v("Add Book")]),r("b-table",{attrs:{striped:"",hover:"",items:t.results,fields:t.fields,responsive:"sm"},scopedSlots:t._u([{key:"cell(thumbnailUrl)",fn:function(t){return[r("b-img",{attrs:{src:t.value,thumbnail:"",fluid:""}})]}},{key:"cell(title_link)",fn:function(e){return[r("b-link",{attrs:{to:{name:"book_view",params:{id:e.item.bookId}}}},[t._v(t._s(e.item.title))])]}}])}),r("transition",{attrs:{name:"fade"}},[r("div",{directives:[{name:"show",rawName:"v-show",value:t.dataIsLoading,expression:"dataIsLoading"}],staticClass:"spinner-container"},[r("div",{staticClass:"spinner"})])]),r("div",{staticClass:"overflow-auto"},[r("div",[r("b-pagination",{attrs:{"total-rows":t.resultsCount,"per-page":t.resultsPerPage,"first-number":"","last-number":"",size:"md"},model:{value:t.activePage,callback:function(e){t.activePage=e},expression:"activePage"}})],1)]),t.error?r("p",[t._v(t._s(t.error.message))]):t._e()],1)},o=[],a=(r("99af"),r("d3b7"),r("ac1f"),r("841c"),r("498a"),r("bc3a")),s=r.n(a),i={name:"Home",props:{msg:String},data:function(){return{activePage:1,baseUrl:"https://localhost:5001/books",dataIsLoading:!0,error:null,results:[],resultsCount:0,resultsPerPage:10,searchText:"",fields:[{key:"thumbnailUrl",label:"Book Image"},{key:"title_link",label:"Book Title",sortable:!0,sortDirection:"desc"},{key:"isbn",label:"ISBN",sortable:!0,sortDirection:"desc"},{key:"descr",label:"Description",sortable:!0,sortDirection:"desc"}]}},computed:{url:function(){return""==this.searchText.trim()?"".concat(this.baseUrl,"/Books/").concat(this.resultsPerPage,"/").concat((this.activePage-1)*this.resultsPerPage):"".concat(this.baseUrl,"/Books/").concat(this.resultsPerPage,"/").concat((this.activePage-1)*this.resultsPerPage,"/").concat(this.search)},counturl:function(){return""==this.searchText.trim()?"".concat(this.baseUrl,"/BooksCount"):"".concat(this.baseUrl,"/BooksCount/").concat(this.search)},pagesCount:function(){return Math.ceil(this.resultsCount/this.resultsPerPage)},search:function(){return this.searchText.trim().toLowerCase()}},watch:{activePage:function(){this.updateBooksData()}},created:function(){this.getBooksData()},methods:{getBooksData:function(){var t=this;s.a.get(this.url).then((function(e){t.getBooksCount(),t.setResults(e.data)})).catch((function(e){t.updateError(e)})).finally((function(){return t.dataIsLoading=!1}))},getBooksCount:function(){var t=this;s.a.get(this.counturl).then((function(e){t.setResultsCount(e.data)})).catch((function(e){t.updateError(e)}))},getFilteredBooksData:function(){this.activePage=1,this.getBooksData()},setActivePage:function(t){this.activePage=t},setResultsCount:function(t){this.resultsCount=t},setResults:function(t){this.results=t},updateError:function(t){this.error=t},removeResults:function(){this.results=[]},removeError:function(){this.error=null},updateBooksData:function(){this.dataIsLoading=!0,this.removeResults(),this.removeError(),this.getBooksData()}}},u=i,c=(r("f517"),r("2877")),l=Object(c["a"])(u,n,o,!1,null,"eccbdcec",null);e["default"]=l.exports},"60f2":function(t,e,r){},f517:function(t,e,r){"use strict";var n=r("60f2"),o=r.n(n);o.a}});
//# sourceMappingURL=app.a4577d27.js.map