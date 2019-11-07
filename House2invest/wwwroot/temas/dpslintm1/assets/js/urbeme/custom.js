/* LOAD JQUERY VALIDATION
 VERSION: 1.15.0
 RELESAED: 2/24/2016
 URL: http://jqueryvalidation.org/
 COPYRIGHT (c) 2016 Jörn Zaefferer;
 LICENSED MIT */
!function (a) { "function" == typeof define && define.amd ? define(["jquery"], a) : "object" == typeof module && module.exports ? module.exports = a(require("jquery")) : a(jQuery) }(function (a) { a.extend(a.fn, { validate: function (b) { if (!this.length) return void (b && b.debug && window.console && console.warn("Nothing selected, can't validate, returning nothing.")); var c = a.data(this[0], "validator"); return c ? c : (this.attr("novalidate", "novalidate"), c = new a.validator(b, this[0]), a.data(this[0], "validator", c), c.settings.onsubmit && (this.on("click.validate", ":submit", function (b) { c.settings.submitHandler && (c.submitButton = b.target), a(this).hasClass("cancel") && (c.cancelSubmit = !0), void 0 !== a(this).attr("formnovalidate") && (c.cancelSubmit = !0) }), this.on("submit.validate", function (b) { function d() { var d, e; return c.settings.submitHandler ? (c.submitButton && (d = a("<input type='hidden'/>").attr("name", c.submitButton.name).val(a(c.submitButton).val()).appendTo(c.currentForm)), e = c.settings.submitHandler.call(c, c.currentForm, b), c.submitButton && d.remove(), void 0 !== e ? e : !1) : !0 } return c.settings.debug && b.preventDefault(), c.cancelSubmit ? (c.cancelSubmit = !1, d()) : c.form() ? c.pendingRequest ? (c.formSubmitted = !0, !1) : d() : (c.focusInvalid(), !1) })), c) }, valid: function () { var b, c, d; return a(this[0]).is("form") ? b = this.validate().form() : (d = [], b = !0, c = a(this[0].form).validate(), this.each(function () { b = c.element(this) && b, b || (d = d.concat(c.errorList)) }), c.errorList = d), b }, rules: function (b, c) { if (this.length) { var d, e, f, g, h, i, j = this[0]; if (b) switch (d = a.data(j.form, "validator").settings, e = d.rules, f = a.validator.staticRules(j), b) { case "add": a.extend(f, a.validator.normalizeRule(c)), delete f.messages, e[j.name] = f, c.messages && (d.messages[j.name] = a.extend(d.messages[j.name], c.messages)); break; case "remove": return c ? (i = {}, a.each(c.split(/\s/), function (b, c) { i[c] = f[c], delete f[c], "required" === c && a(j).removeAttr("aria-required") }), i) : (delete e[j.name], f) }return g = a.validator.normalizeRules(a.extend({}, a.validator.classRules(j), a.validator.attributeRules(j), a.validator.dataRules(j), a.validator.staticRules(j)), j), g.required && (h = g.required, delete g.required, g = a.extend({ required: h }, g), a(j).attr("aria-required", "true")), g.remote && (h = g.remote, delete g.remote, g = a.extend(g, { remote: h })), g } } }), a.extend(a.expr[":"], { blank: function (b) { return !a.trim("" + a(b).val()) }, filled: function (b) { var c = a(b).val(); return null !== c && !!a.trim("" + c) }, unchecked: function (b) { return !a(b).prop("checked") } }), a.validator = function (b, c) { this.settings = a.extend(!0, {}, a.validator.defaults, b), this.currentForm = c, this.init() }, a.validator.format = function (b, c) { return 1 === arguments.length ? function () { var c = a.makeArray(arguments); return c.unshift(b), a.validator.format.apply(this, c) } : void 0 === c ? b : (arguments.length > 2 && c.constructor !== Array && (c = a.makeArray(arguments).slice(1)), c.constructor !== Array && (c = [c]), a.each(c, function (a, c) { b = b.replace(new RegExp("\\{" + a + "\\}", "g"), function () { return c }) }), b) }, a.extend(a.validator, { defaults: { messages: {}, groups: {}, rules: {}, errorClass: "error", pendingClass: "pending", validClass: "valid", errorElement: "label", focusCleanup: !1, focusInvalid: !0, errorContainer: a([]), errorLabelContainer: a([]), onsubmit: !0, ignore: ":hidden", ignoreTitle: !1, onfocusin: function (a) { this.lastActive = a, this.settings.focusCleanup && (this.settings.unhighlight && this.settings.unhighlight.call(this, a, this.settings.errorClass, this.settings.validClass), this.hideThese(this.errorsFor(a))) }, onfocusout: function (a) { this.checkable(a) || !(a.name in this.submitted) && this.optional(a) || this.element(a) }, onkeyup: function (b, c) { var d = [16, 17, 18, 20, 35, 36, 37, 38, 39, 40, 45, 144, 225]; 9 === c.which && "" === this.elementValue(b) || -1 !== a.inArray(c.keyCode, d) || (b.name in this.submitted || b.name in this.invalid) && this.element(b) }, onclick: function (a) { a.name in this.submitted ? this.element(a) : a.parentNode.name in this.submitted && this.element(a.parentNode) }, highlight: function (b, c, d) { "radio" === b.type ? this.findByName(b.name).addClass(c).removeClass(d) : a(b).addClass(c).removeClass(d) }, unhighlight: function (b, c, d) { "radio" === b.type ? this.findByName(b.name).removeClass(c).addClass(d) : a(b).removeClass(c).addClass(d) } }, setDefaults: function (b) { a.extend(a.validator.defaults, b) }, messages: { required: "This field is required.", remote: "Please fix this field.", email: "Please enter a valid email address.", url: "Please enter a valid URL.", date: "Please enter a valid date.", dateISO: "Please enter a valid date ( ISO ).", number: "Please enter a valid number.", digits: "Please enter only digits.", equalTo: "Please enter the same value again.", maxlength: a.validator.format("Please enter no more than {0} characters."), minlength: a.validator.format("Please enter at least {0} characters."), rangelength: a.validator.format("Please enter a value between {0} and {1} characters long."), range: a.validator.format("Please enter a value between {0} and {1}."), max: a.validator.format("Please enter a value less than or equal to {0}."), min: a.validator.format("Please enter a value greater than or equal to {0}."), step: a.validator.format("Please enter a multiple of {0}.") }, autoCreateRanges: !1, prototype: { init: function () { function b(b) { var c = a.data(this.form, "validator"), d = "on" + b.type.replace(/^validate/, ""), e = c.settings; e[d] && !a(this).is(e.ignore) && e[d].call(c, this, b) } this.labelContainer = a(this.settings.errorLabelContainer), this.errorContext = this.labelContainer.length && this.labelContainer || a(this.currentForm), this.containers = a(this.settings.errorContainer).add(this.settings.errorLabelContainer), this.submitted = {}, this.valueCache = {}, this.pendingRequest = 0, this.pending = {}, this.invalid = {}, this.reset(); var c, d = this.groups = {}; a.each(this.settings.groups, function (b, c) { "string" == typeof c && (c = c.split(/\s/)), a.each(c, function (a, c) { d[c] = b }) }), c = this.settings.rules, a.each(c, function (b, d) { c[b] = a.validator.normalizeRule(d) }), a(this.currentForm).on("focusin.validate focusout.validate keyup.validate", ":text, [type='password'], [type='file'], select, textarea, [type='number'], [type='search'], [type='tel'], [type='url'], [type='email'], [type='datetime'], [type='date'], [type='month'], [type='week'], [type='time'], [type='datetime-local'], [type='range'], [type='color'], [type='radio'], [type='checkbox'], [contenteditable]", b).on("click.validate", "select, option, [type='radio'], [type='checkbox']", b), this.settings.invalidHandler && a(this.currentForm).on("invalid-form.validate", this.settings.invalidHandler), a(this.currentForm).find("[required], [data-rule-required], .required").attr("aria-required", "true") }, form: function () { return this.checkForm(), a.extend(this.submitted, this.errorMap), this.invalid = a.extend({}, this.errorMap), this.valid() || a(this.currentForm).triggerHandler("invalid-form", [this]), this.showErrors(), this.valid() }, checkForm: function () { this.prepareForm(); for (var a = 0, b = this.currentElements = this.elements(); b[a]; a++)this.check(b[a]); return this.valid() }, element: function (b) { var c, d, e = this.clean(b), f = this.validationTargetFor(e), g = this, h = !0; return void 0 === f ? delete this.invalid[e.name] : (this.prepareElement(f), this.currentElements = a(f), d = this.groups[f.name], d && a.each(this.groups, function (a, b) { b === d && a !== f.name && (e = g.validationTargetFor(g.clean(g.findByName(a))), e && e.name in g.invalid && (g.currentElements.push(e), h = h && g.check(e))) }), c = this.check(f) !== !1, h = h && c, c ? this.invalid[f.name] = !1 : this.invalid[f.name] = !0, this.numberOfInvalids() || (this.toHide = this.toHide.add(this.containers)), this.showErrors(), a(b).attr("aria-invalid", !c)), h }, showErrors: function (b) { if (b) { var c = this; a.extend(this.errorMap, b), this.errorList = a.map(this.errorMap, function (a, b) { return { message: a, element: c.findByName(b)[0] } }), this.successList = a.grep(this.successList, function (a) { return !(a.name in b) }) } this.settings.showErrors ? this.settings.showErrors.call(this, this.errorMap, this.errorList) : this.defaultShowErrors() }, resetForm: function () { a.fn.resetForm && a(this.currentForm).resetForm(), this.invalid = {}, this.submitted = {}, this.prepareForm(), this.hideErrors(); var b = this.elements().removeData("previousValue").removeAttr("aria-invalid"); this.resetElements(b) }, resetElements: function (a) { var b; if (this.settings.unhighlight) for (b = 0; a[b]; b++)this.settings.unhighlight.call(this, a[b], this.settings.errorClass, ""), this.findByName(a[b].name).removeClass(this.settings.validClass); else a.removeClass(this.settings.errorClass).removeClass(this.settings.validClass) }, numberOfInvalids: function () { return this.objectLength(this.invalid) }, objectLength: function (a) { var b, c = 0; for (b in a) a[b] && c++; return c }, hideErrors: function () { this.hideThese(this.toHide) }, hideThese: function (a) { a.not(this.containers).text(""), this.addWrapper(a).hide() }, valid: function () { return 0 === this.size() }, size: function () { return this.errorList.length }, focusInvalid: function () { if (this.settings.focusInvalid) try { a(this.findLastActive() || this.errorList.length && this.errorList[0].element || []).filter(":visible").focus().trigger("focusin") } catch (b) { } }, findLastActive: function () { var b = this.lastActive; return b && 1 === a.grep(this.errorList, function (a) { return a.element.name === b.name }).length && b }, elements: function () { var b = this, c = {}; return a(this.currentForm).find("input, select, textarea, [contenteditable]").not(":submit, :reset, :image, :disabled").not(this.settings.ignore).filter(function () { var d = this.name || a(this).attr("name"); return !d && b.settings.debug && window.console && console.error("%o has no name assigned", this), this.hasAttribute("contenteditable") && (this.form = a(this).closest("form")[0]), d in c || !b.objectLength(a(this).rules()) ? !1 : (c[d] = !0, !0) }) }, clean: function (b) { return a(b)[0] }, errors: function () { var b = this.settings.errorClass.split(" ").join("."); return a(this.settings.errorElement + "." + b, this.errorContext) }, resetInternals: function () { this.successList = [], this.errorList = [], this.errorMap = {}, this.toShow = a([]), this.toHide = a([]) }, reset: function () { this.resetInternals(), this.currentElements = a([]) }, prepareForm: function () { this.reset(), this.toHide = this.errors().add(this.containers) }, prepareElement: function (a) { this.reset(), this.toHide = this.errorsFor(a) }, elementValue: function (b) { var c, d, e = a(b), f = b.type; return "radio" === f || "checkbox" === f ? this.findByName(b.name).filter(":checked").val() : "number" === f && "undefined" != typeof b.validity ? b.validity.badInput ? "NaN" : e.val() : (c = b.hasAttribute("contenteditable") ? e.text() : e.val(), "file" === f ? "C:\\fakepath\\" === c.substr(0, 12) ? c.substr(12) : (d = c.lastIndexOf("/"), d >= 0 ? c.substr(d + 1) : (d = c.lastIndexOf("\\"), d >= 0 ? c.substr(d + 1) : c)) : "string" == typeof c ? c.replace(/\r/g, "") : c) }, check: function (b) { b = this.validationTargetFor(this.clean(b)); var c, d, e, f = a(b).rules(), g = a.map(f, function (a, b) { return b }).length, h = !1, i = this.elementValue(b); if ("function" == typeof f.normalizer) { if (i = f.normalizer.call(b, i), "string" != typeof i) throw new TypeError("The normalizer should return a string value."); delete f.normalizer } for (d in f) { e = { method: d, parameters: f[d] }; try { if (c = a.validator.methods[d].call(this, i, b, e.parameters), "dependency-mismatch" === c && 1 === g) { h = !0; continue } if (h = !1, "pending" === c) return void (this.toHide = this.toHide.not(this.errorsFor(b))); if (!c) return this.formatAndAdd(b, e), !1 } catch (j) { throw this.settings.debug && window.console && console.log("Exception occurred when checking element " + b.id + ", check the '" + e.method + "' method.", j), j instanceof TypeError && (j.message += ".  Exception occurred when checking element " + b.id + ", check the '" + e.method + "' method."), j } } if (!h) return this.objectLength(f) && this.successList.push(b), !0 }, customDataMessage: function (b, c) { return a(b).data("msg" + c.charAt(0).toUpperCase() + c.substring(1).toLowerCase()) || a(b).data("msg") }, customMessage: function (a, b) { var c = this.settings.messages[a]; return c && (c.constructor === String ? c : c[b]) }, findDefined: function () { for (var a = 0; a < arguments.length; a++)if (void 0 !== arguments[a]) return arguments[a] }, defaultMessage: function (b, c) { var d = this.findDefined(this.customMessage(b.name, c.method), this.customDataMessage(b, c.method), !this.settings.ignoreTitle && b.title || void 0, a.validator.messages[c.method], "<strong>Warning: No message defined for " + b.name + "</strong>"), e = /\$?\{(\d+)\}/g; return "function" == typeof d ? d = d.call(this, c.parameters, b) : e.test(d) && (d = a.validator.format(d.replace(e, "{$1}"), c.parameters)), d }, formatAndAdd: function (a, b) { var c = this.defaultMessage(a, b); this.errorList.push({ message: c, element: a, method: b.method }), this.errorMap[a.name] = c, this.submitted[a.name] = c }, addWrapper: function (a) { return this.settings.wrapper && (a = a.add(a.parent(this.settings.wrapper))), a }, defaultShowErrors: function () { var a, b, c; for (a = 0; this.errorList[a]; a++)c = this.errorList[a], this.settings.highlight && this.settings.highlight.call(this, c.element, this.settings.errorClass, this.settings.validClass), this.showLabel(c.element, c.message); if (this.errorList.length && (this.toShow = this.toShow.add(this.containers)), this.settings.success) for (a = 0; this.successList[a]; a++)this.showLabel(this.successList[a]); if (this.settings.unhighlight) for (a = 0, b = this.validElements(); b[a]; a++)this.settings.unhighlight.call(this, b[a], this.settings.errorClass, this.settings.validClass); this.toHide = this.toHide.not(this.toShow), this.hideErrors(), this.addWrapper(this.toShow).show() }, validElements: function () { return this.currentElements.not(this.invalidElements()) }, invalidElements: function () { return a(this.errorList).map(function () { return this.element }) }, showLabel: function (b, c) { var d, e, f, g, h = this.errorsFor(b), i = this.idOrName(b), j = a(b).attr("aria-describedby"); h.length ? (h.removeClass(this.settings.validClass).addClass(this.settings.errorClass), h.html(c)) : (h = a("<" + this.settings.errorElement + ">").attr("id", i + "-error").addClass(this.settings.errorClass).html(c || ""), d = h, this.settings.wrapper && (d = h.hide().show().wrap("<" + this.settings.wrapper + "/>").parent()), this.labelContainer.length ? this.labelContainer.append(d) : this.settings.errorPlacement ? this.settings.errorPlacement(d, a(b)) : d.insertAfter(b), h.is("label") ? h.attr("for", i) : 0 === h.parents("label[for='" + this.escapeCssMeta(i) + "']").length && (f = h.attr("id"), j ? j.match(new RegExp("\\b" + this.escapeCssMeta(f) + "\\b")) || (j += " " + f) : j = f, a(b).attr("aria-describedby", j), e = this.groups[b.name], e && (g = this, a.each(g.groups, function (b, c) { c === e && a("[name='" + g.escapeCssMeta(b) + "']", g.currentForm).attr("aria-describedby", h.attr("id")) })))), !c && this.settings.success && (h.text(""), "string" == typeof this.settings.success ? h.addClass(this.settings.success) : this.settings.success(h, b)), this.toShow = this.toShow.add(h) }, errorsFor: function (b) { var c = this.escapeCssMeta(this.idOrName(b)), d = a(b).attr("aria-describedby"), e = "label[for='" + c + "'], label[for='" + c + "'] *"; return d && (e = e + ", #" + this.escapeCssMeta(d).replace(/\s+/g, ", #")), this.errors().filter(e) }, escapeCssMeta: function (a) { return a.replace(/([\\!"#$%&'()*+,./:;<=>?@\[\]^`{|}~])/g, "\\$1") }, idOrName: function (a) { return this.groups[a.name] || (this.checkable(a) ? a.name : a.id || a.name) }, validationTargetFor: function (b) { return this.checkable(b) && (b = this.findByName(b.name)), a(b).not(this.settings.ignore)[0] }, checkable: function (a) { return /radio|checkbox/i.test(a.type) }, findByName: function (b) { return a(this.currentForm).find("[name='" + this.escapeCssMeta(b) + "']") }, getLength: function (b, c) { switch (c.nodeName.toLowerCase()) { case "select": return a("option:selected", c).length; case "input": if (this.checkable(c)) return this.findByName(c.name).filter(":checked").length }return b.length }, depend: function (a, b) { return this.dependTypes[typeof a] ? this.dependTypes[typeof a](a, b) : !0 }, dependTypes: { "boolean": function (a) { return a }, string: function (b, c) { return !!a(b, c.form).length }, "function": function (a, b) { return a(b) } }, optional: function (b) { var c = this.elementValue(b); return !a.validator.methods.required.call(this, c, b) && "dependency-mismatch" }, startRequest: function (b) { this.pending[b.name] || (this.pendingRequest++ , a(b).addClass(this.settings.pendingClass), this.pending[b.name] = !0) }, stopRequest: function (b, c) { this.pendingRequest-- , this.pendingRequest < 0 && (this.pendingRequest = 0), delete this.pending[b.name], a(b).removeClass(this.settings.pendingClass), c && 0 === this.pendingRequest && this.formSubmitted && this.form() ? (a(this.currentForm).submit(), this.formSubmitted = !1) : !c && 0 === this.pendingRequest && this.formSubmitted && (a(this.currentForm).triggerHandler("invalid-form", [this]), this.formSubmitted = !1) }, previousValue: function (b, c) { return a.data(b, "previousValue") || a.data(b, "previousValue", { old: null, valid: !0, message: this.defaultMessage(b, { method: c }) }) }, destroy: function () { this.resetForm(), a(this.currentForm).off(".validate").removeData("validator").find(".validate-equalTo-blur").off(".validate-equalTo").removeClass("validate-equalTo-blur") } }, classRuleSettings: { required: { required: !0 }, email: { email: !0 }, url: { url: !0 }, date: { date: !0 }, dateISO: { dateISO: !0 }, number: { number: !0 }, digits: { digits: !0 }, creditcard: { creditcard: !0 } }, addClassRules: function (b, c) { b.constructor === String ? this.classRuleSettings[b] = c : a.extend(this.classRuleSettings, b) }, classRules: function (b) { var c = {}, d = a(b).attr("class"); return d && a.each(d.split(" "), function () { this in a.validator.classRuleSettings && a.extend(c, a.validator.classRuleSettings[this]) }), c }, normalizeAttributeRule: function (a, b, c, d) { /min|max|step/.test(c) && (null === b || /number|range|text/.test(b)) && (d = Number(d), isNaN(d) && (d = void 0)), d || 0 === d ? a[c] = d : b === c && "range" !== b && (a[c] = !0) }, attributeRules: function (b) { var c, d, e = {}, f = a(b), g = b.getAttribute("type"); for (c in a.validator.methods) "required" === c ? (d = b.getAttribute(c), "" === d && (d = !0), d = !!d) : d = f.attr(c), this.normalizeAttributeRule(e, g, c, d); return e.maxlength && /-1|2147483647|524288/.test(e.maxlength) && delete e.maxlength, e }, dataRules: function (b) { var c, d, e = {}, f = a(b), g = b.getAttribute("type"); for (c in a.validator.methods) d = f.data("rule" + c.charAt(0).toUpperCase() + c.substring(1).toLowerCase()), this.normalizeAttributeRule(e, g, c, d); return e }, staticRules: function (b) { var c = {}, d = a.data(b.form, "validator"); return d.settings.rules && (c = a.validator.normalizeRule(d.settings.rules[b.name]) || {}), c }, normalizeRules: function (b, c) { return a.each(b, function (d, e) { if (e === !1) return void delete b[d]; if (e.param || e.depends) { var f = !0; switch (typeof e.depends) { case "string": f = !!a(e.depends, c.form).length; break; case "function": f = e.depends.call(c, c) }f ? b[d] = void 0 !== e.param ? e.param : !0 : (a.data(c.form, "validator").resetElements(a(c)), delete b[d]) } }), a.each(b, function (d, e) { b[d] = a.isFunction(e) && "normalizer" !== d ? e(c) : e }), a.each(["minlength", "maxlength"], function () { b[this] && (b[this] = Number(b[this])) }), a.each(["rangelength", "range"], function () { var c; b[this] && (a.isArray(b[this]) ? b[this] = [Number(b[this][0]), Number(b[this][1])] : "string" == typeof b[this] && (c = b[this].replace(/[\[\]]/g, "").split(/[\s,]+/), b[this] = [Number(c[0]), Number(c[1])])) }), a.validator.autoCreateRanges && (null != b.min && null != b.max && (b.range = [b.min, b.max], delete b.min, delete b.max), null != b.minlength && null != b.maxlength && (b.rangelength = [b.minlength, b.maxlength], delete b.minlength, delete b.maxlength)), b }, normalizeRule: function (b) { if ("string" == typeof b) { var c = {}; a.each(b.split(/\s/), function () { c[this] = !0 }), b = c } return b }, addMethod: function (b, c, d) { a.validator.methods[b] = c, a.validator.messages[b] = void 0 !== d ? d : a.validator.messages[b], c.length < 3 && a.validator.addClassRules(b, a.validator.normalizeRule(b)) }, methods: { required: function (b, c, d) { if (!this.depend(d, c)) return "dependency-mismatch"; if ("select" === c.nodeName.toLowerCase()) { var e = a(c).val(); return e && e.length > 0 } return this.checkable(c) ? this.getLength(b, c) > 0 : b.length > 0 }, email: function (a, b) { return this.optional(b) || /^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/.test(a) }, url: function (a, b) { return this.optional(b) || /^(?:(?:(?:https?|ftp):)?\/\/)(?:\S+(?::\S*)?@)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})).?)(?::\d{2,5})?(?:[/?#]\S*)?$/i.test(a) }, date: function (a, b) { return this.optional(b) || !/Invalid|NaN/.test(new Date(a).toString()) }, dateISO: function (a, b) { return this.optional(b) || /^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])$/.test(a) }, number: function (a, b) { return this.optional(b) || /^(?:-?\d+|-?\d{1,3}(?:,\d{3})+)?(?:\.\d+)?$/.test(a) }, digits: function (a, b) { return this.optional(b) || /^\d+$/.test(a) }, minlength: function (b, c, d) { var e = a.isArray(b) ? b.length : this.getLength(b, c); return this.optional(c) || e >= d }, maxlength: function (b, c, d) { var e = a.isArray(b) ? b.length : this.getLength(b, c); return this.optional(c) || d >= e }, rangelength: function (b, c, d) { var e = a.isArray(b) ? b.length : this.getLength(b, c); return this.optional(c) || e >= d[0] && e <= d[1] }, min: function (a, b, c) { return this.optional(b) || a >= c }, max: function (a, b, c) { return this.optional(b) || c >= a }, range: function (a, b, c) { return this.optional(b) || a >= c[0] && a <= c[1] }, step: function (b, c, d) { var e = a(c).attr("type"), f = "Step attribute on input type " + e + " is not supported.", g = ["text", "number", "range"], h = new RegExp("\\b" + e + "\\b"), i = e && !h.test(g.join()); if (i) throw new Error(f); return this.optional(c) || b % d === 0 }, equalTo: function (b, c, d) { var e = a(d); return this.settings.onfocusout && e.not(".validate-equalTo-blur").length && e.addClass("validate-equalTo-blur").on("blur.validate-equalTo", function () { a(c).valid() }), b === e.val() }, remote: function (b, c, d, e) { if (this.optional(c)) return "dependency-mismatch"; e = "string" == typeof e && e || "remote"; var f, g, h, i = this.previousValue(c, e); return this.settings.messages[c.name] || (this.settings.messages[c.name] = {}), i.originalMessage = i.originalMessage || this.settings.messages[c.name][e], this.settings.messages[c.name][e] = i.message, d = "string" == typeof d && { url: d } || d, h = a.param(a.extend({ data: b }, d.data)), i.old === h ? i.valid : (i.old = h, f = this, this.startRequest(c), g = {}, g[c.name] = b, a.ajax(a.extend(!0, { mode: "abort", port: "validate" + c.name, dataType: "json", data: g, context: f.currentForm, success: function (a) { var d, g, h, j = a === !0 || "true" === a; f.settings.messages[c.name][e] = i.originalMessage, j ? (h = f.formSubmitted, f.resetInternals(), f.toHide = f.errorsFor(c), f.formSubmitted = h, f.successList.push(c), f.invalid[c.name] = !1, f.showErrors()) : (d = {}, g = a || f.defaultMessage(c, { method: e, parameters: b }), d[c.name] = i.message = g, f.invalid[c.name] = !0, f.showErrors(d)), i.valid = j, f.stopRequest(c, j) } }, d)), "pending") } } }); var b, c = {}; a.ajaxPrefilter ? a.ajaxPrefilter(function (a, b, d) { var e = a.port; "abort" === a.mode && (c[e] && c[e].abort(), c[e] = d) }) : (b = a.ajax, a.ajax = function (d) { var e = ("mode" in d ? d : a.ajaxSettings).mode, f = ("port" in d ? d : a.ajaxSettings).port; return "abort" === e ? (c[f] && c[f].abort(), c[f] = b.apply(this, arguments), c[f]) : b.apply(this, arguments) }) });

/* LOAD JQUERY MASK
   github.com/igorescobar/jQuery-Mask-Plugin
*/
var $jscomp = { scope: {}, findInternal: function (t, a, e) { t instanceof String && (t = String(t)); for (var n = t.length, s = 0; s < n; s++) { var r = t[s]; if (a.call(e, r, s, t)) return { i: s, v: r } } return { i: -1, v: void 0 } } }; $jscomp.defineProperty = "function" == typeof Object.defineProperties ? Object.defineProperty : function (t, a, e) { if (e.get || e.set) throw new TypeError("ES3 does not support getters and setters."); t != Array.prototype && t != Object.prototype && (t[a] = e.value) }, $jscomp.getGlobal = function (t) { return "undefined" != typeof window && window === t ? t : "undefined" != typeof global && null != global ? global : t }, $jscomp.global = $jscomp.getGlobal(this), $jscomp.polyfill = function (t, a, e, n) { if (a) { for (e = $jscomp.global, t = t.split("."), n = 0; n < t.length - 1; n++) { var s = t[n]; s in e || (e[s] = {}), e = e[s] } (a = a(n = e[t = t[t.length - 1]])) != n && null != a && $jscomp.defineProperty(e, t, { configurable: !0, writable: !0, value: a }) } }, $jscomp.polyfill("Array.prototype.find", function (t) { return t || function (t, a) { return $jscomp.findInternal(this, t, a).v } }, "es6-impl", "es3"), function (t, a, e) { "function" == typeof define && define.amd ? define(["jquery"], t) : "object" == typeof exports ? module.exports = t(require("jquery")) : t(a || e) }(function (t) { var a = function (a, e, n) { var s = { invalid: [], getCaret: function () { try { var t, e = 0, n = a.get(0), r = document.selection, o = n.selectionStart; return r && -1 === navigator.appVersion.indexOf("MSIE 10") ? ((t = r.createRange()).moveStart("character", -s.val().length), e = t.text.length) : (o || "0" === o) && (e = o), e } catch (t) { } }, setCaret: function (t) { try { if (a.is(":focus")) { var e, n = a.get(0); n.setSelectionRange ? n.setSelectionRange(t, t) : ((e = n.createTextRange()).collapse(!0), e.moveEnd("character", t), e.moveStart("character", t), e.select()) } } catch (t) { } }, events: function () { a.on("keydown.mask", function (t) { a.data("mask-keycode", t.keyCode || t.which), a.data("mask-previus-value", a.val()), a.data("mask-previus-caret-pos", s.getCaret()), s.maskDigitPosMapOld = s.maskDigitPosMap }).on(t.jMaskGlobals.useInput ? "input.mask" : "keyup.mask", s.behaviour).on("paste.mask drop.mask", function () { setTimeout(function () { a.keydown().keyup() }, 100) }).on("change.mask", function () { a.data("changed", !0) }).on("blur.mask", function () { i === s.val() || a.data("changed") || a.trigger("change"), a.data("changed", !1) }).on("blur.mask", function () { i = s.val() }).on("focus.mask", function (a) { !0 === n.selectOnFocus && t(a.target).select() }).on("focusout.mask", function () { n.clearIfNotMatch && !r.test(s.val()) && s.val("") }) }, getRegexMask: function () { for (var t, a, n, s, r = [], i = 0; i < e.length; i++)(t = o.translation[e.charAt(i)]) ? (a = t.pattern.toString().replace(/.{1}$|^.{1}/g, ""), n = t.optional, (t = t.recursive) ? (r.push(e.charAt(i)), s = { digit: e.charAt(i), pattern: a }) : r.push(n || t ? a + "?" : a)) : r.push(e.charAt(i).replace(/[-\/\\^$*+?.()|[\]{}]/g, "\\$&")); return r = r.join(""), s && (r = r.replace(new RegExp("(" + s.digit + "(.*" + s.digit + ")?)"), "($1)?").replace(new RegExp(s.digit, "g"), s.pattern)), new RegExp(r) }, destroyEvents: function () { a.off("input keydown keyup paste drop blur focusout ".split(" ").join(".mask ")) }, val: function (t) { var e = a.is("input") ? "val" : "text"; return 0 < arguments.length ? (a[e]() !== t && a[e](t), e = a) : e = a[e](), e }, calculateCaretPosition: function () { var t = a.data("mask-previus-value") || "", e = s.getMasked(), n = s.getCaret(); if (t !== e) { var r, o = a.data("mask-previus-caret-pos") || 0, i = (e = e.length, t.length), l = t = 0, c = 0, u = 0; for (r = n; r < e && s.maskDigitPosMap[r]; r++)l++; for (r = n - 1; 0 <= r && s.maskDigitPosMap[r]; r--)t++; for (r = n - 1; 0 <= r; r--)s.maskDigitPosMap[r] && c++; for (r = o - 1; 0 <= r; r--)s.maskDigitPosMapOld[r] && u++; n > i ? n = e : o >= n && o !== i ? s.maskDigitPosMapOld[n] || (o = n, n = n - (u - c) - t, s.maskDigitPosMap[n] && (n = o)) : n > o && (n = n + (c - u) + l) } return n }, behaviour: function (e) { e = e || window.event, s.invalid = []; var n = a.data("mask-keycode"); if (-1 === t.inArray(n, o.byPassKeys)) { n = s.getMasked(); var r = s.getCaret(); return setTimeout(function () { s.setCaret(s.calculateCaretPosition()) }, 10), s.val(n), s.setCaret(r), s.callbacks(e) } }, getMasked: function (t, a) { var r, i, l, c = [], u = void 0 === a ? s.val() : a + "", f = 0, p = e.length, d = 0, k = u.length, v = 1, h = "push", g = -1, m = 0, y = []; for (n.reverse ? (h = "unshift", v = -1, r = 0, f = p - 1, d = k - 1, i = function () { return -1 < f && -1 < d }) : (r = p - 1, i = function () { return f < p && d < k }); i();) { var M = e.charAt(f), b = u.charAt(d), j = o.translation[M]; j ? (b.match(j.pattern) ? (c[h](b), j.recursive && (-1 === g ? g = f : f === r && (f = g - v), r === g && (f -= v)), f += v) : b === l ? (m-- , l = void 0) : j.optional ? (f += v, d -= v) : j.fallback ? (c[h](j.fallback), f += v, d -= v) : s.invalid.push({ p: d, v: b, e: j.pattern }), d += v) : (t || c[h](M), b === M ? (y.push(d), d += v) : (l = M, y.push(d + m), m++), f += v) } return u = e.charAt(r), p !== k + 1 || o.translation[u] || c.push(u), c = c.join(""), s.mapMaskdigitPositions(c, y, k), c }, mapMaskdigitPositions: function (t, a, e) { for (t = n.reverse ? t.length - e : 0, s.maskDigitPosMap = {}, e = 0; e < a.length; e++)s.maskDigitPosMap[a[e] + t] = 1 }, callbacks: function (t) { var r = s.val(), o = r !== i, l = [r, t, a, n], c = function (t, a, e) { "function" == typeof n[t] && a && n[t].apply(this, e) }; c("onChange", !0 === o, l), c("onKeyPress", !0 === o, l), c("onComplete", r.length === e.length, l), c("onInvalid", 0 < s.invalid.length, [r, t, a, s.invalid, n]) } }; a = t(a); var r, o = this, i = s.val(); e = "function" == typeof e ? e(s.val(), void 0, a, n) : e, o.mask = e, o.options = n, o.remove = function () { var t = s.getCaret(); return s.destroyEvents(), s.val(o.getCleanVal()), s.setCaret(t), a }, o.getCleanVal = function () { return s.getMasked(!0) }, o.getMaskedVal = function (t) { return s.getMasked(!1, t) }, o.init = function (i) { if (i = i || !1, n = n || {}, o.clearIfNotMatch = t.jMaskGlobals.clearIfNotMatch, o.byPassKeys = t.jMaskGlobals.byPassKeys, o.translation = t.extend({}, t.jMaskGlobals.translation, n.translation), o = t.extend(!0, {}, o, n), r = s.getRegexMask(), i) s.events(), s.val(s.getMasked()); else { n.placeholder && a.attr("placeholder", n.placeholder), a.data("mask") && a.attr("autocomplete", "off"), i = 0; for (var l = !0; i < e.length; i++) { var c = o.translation[e.charAt(i)]; if (c && c.recursive) { l = !1; break } } l && a.attr("maxlength", e.length), s.destroyEvents(), s.events(), i = s.getCaret(), s.val(s.getMasked()), s.setCaret(i) } }, o.init(!a.is("input")) }; t.maskWatchers = {}; var e = function () { var e = t(this), s = {}, r = e.attr("data-mask"); if (e.attr("data-mask-reverse") && (s.reverse = !0), e.attr("data-mask-clearifnotmatch") && (s.clearIfNotMatch = !0), "true" === e.attr("data-mask-selectonfocus") && (s.selectOnFocus = !0), n(e, r, s)) return e.data("mask", new a(this, r, s)) }, n = function (a, e, n) { n = n || {}; var s = t(a).data("mask"), r = JSON.stringify; a = t(a).val() || t(a).text(); try { return "function" == typeof e && (e = e(a)), "object" != typeof s || r(s.options) !== r(n) || s.mask !== e } catch (t) { } }, s = function (t) { var a, e = document.createElement("div"); return (a = (t = "on" + t) in e) || (e.setAttribute(t, "return;"), a = "function" == typeof e[t]), a }; t.fn.mask = function (e, s) { s = s || {}; var r = this.selector, o = (i = t.jMaskGlobals).watchInterval, i = s.watchInputs || i.watchInputs, l = function () { if (n(this, e, s)) return t(this).data("mask", new a(this, e, s)) }; return t(this).each(l), r && "" !== r && i && (clearInterval(t.maskWatchers[r]), t.maskWatchers[r] = setInterval(function () { t(document).find(r).each(l) }, o)), this }, t.fn.masked = function (t) { return this.data("mask").getMaskedVal(t) }, t.fn.unmask = function () { return clearInterval(t.maskWatchers[this.selector]), delete t.maskWatchers[this.selector], this.each(function () { var a = t(this).data("mask"); a && a.remove().removeData("mask") }) }, t.fn.cleanVal = function () { return this.data("mask").getCleanVal() }, t.applyDataMask = function (a) { ((a = a || t.jMaskGlobals.maskElements) instanceof t ? a : t(a)).filter(t.jMaskGlobals.dataMaskAttr).each(e) }, s = { maskElements: "input,td,span,div", dataMaskAttr: "*[data-mask]", dataMask: !0, watchInterval: 300, watchInputs: !0, useInput: !/Chrome\/[2-4][0-9]|SamsungBrowser/.test(window.navigator.userAgent) && s("input"), watchDataMask: !1, byPassKeys: [9, 16, 17, 18, 36, 37, 38, 39, 40, 91], translation: { 0: { pattern: /\d/ }, 9: { pattern: /\d/, optional: !0 }, "#": { pattern: /\d/, recursive: !0 }, A: { pattern: /[a-zA-Z0-9]/ }, S: { pattern: /[a-zA-Z]/ } } }, t.jMaskGlobals = t.jMaskGlobals || {}, (s = t.jMaskGlobals = t.extend(!0, {}, s, t.jMaskGlobals)).dataMask && t.applyDataMask(), setInterval(function () { t.jMaskGlobals.watchDataMask && t.applyDataMask() }, s.watchInterval) }, window.jQuery, window.Zepto);

/*!
 * accounting.js v0.4.2, copyright 2014 Open Exchange Rates, MIT license, http://openexchangerates.github.io/accounting.js
 */
!function (n, r) { function e(n) { return !!("" === n || n && n.charCodeAt && n.substr) } function t(n) { return l ? l(n) : "[object Array]" === m.call(n) } function o(n) { return "[object Object]" === m.call(n) } function a(n, r) { var e; n = n || {}, r = r || {}; for (e in r) r.hasOwnProperty(e) && null == n[e] && (n[e] = r[e]); return n } function i(n, r, e) { var t, o, a = []; if (!n) return a; if (p && n.map === p) return n.map(r, e); for (t = 0, o = n.length; t < o; t++)a[t] = r.call(e, n[t], t, n); return a } function u(n, r) { return n = Math.round(Math.abs(n)), isNaN(n) ? r : n } function c(n) { var r = f.settings.currency.format; return "function" == typeof n && (n = n()), e(n) && n.match("%v") ? { pos: n, neg: n.replace("-", "").replace("%v", "-%v"), zero: n } : n && n.pos && n.pos.match("%v") ? n : e(r) ? f.settings.currency.format = { pos: r, neg: r.replace("%v", "-%v"), zero: r } : r } var s, f = { version: "0.4.1", settings: { currency: { symbol: "$", format: "%s%v", decimal: ".", thousand: ",", precision: 2, grouping: 3 }, number: { precision: 0, grouping: 3, thousand: ",", decimal: "." } } }, p = Array.prototype.map, l = Array.isArray, m = Object.prototype.toString, d = f.unformat = f.parse = function (n, r) { if (t(n)) return i(n, function (n) { return d(n, r) }); if ("number" == typeof (n = n || 0)) return n; r = r || "."; var e = RegExp("[^0-9-" + r + "]", ["g"]); e = parseFloat(("" + n).replace(/\((.*)\)/, "-$1").replace(e, "").replace(r, ".")); return isNaN(e) ? 0 : e }, g = f.toFixed = function (n, r) { r = u(r, f.settings.number.precision); var e = Math.pow(10, r); return (Math.round(f.unformat(n) * e) / e).toFixed(r) }, h = f.formatNumber = f.format = function (n, r, e, c) { if (t(n)) return i(n, function (n) { return h(n, r, e, c) }); n = d(n); var s = a(o(r) ? r : { precision: r, thousand: e, decimal: c }, f.settings.number), p = u(s.precision), l = 0 > n ? "-" : "", m = parseInt(g(Math.abs(n || 0), p), 10) + "", y = 3 < m.length ? m.length % 3 : 0; return l + (y ? m.substr(0, y) + s.thousand : "") + m.substr(y).replace(/(\d{3})(?=\d)/g, "$1" + s.thousand) + (p ? s.decimal + g(Math.abs(n), p).split(".")[1] : "") }, y = f.formatMoney = function (n, r, e, s, p, l) { if (t(n)) return i(n, function (n) { return y(n, r, e, s, p, l) }); n = d(n); var m = a(o(r) ? r : { symbol: r, precision: e, thousand: s, decimal: p, format: l }, f.settings.currency), g = c(m.format); return (0 < n ? g.pos : 0 > n ? g.neg : g.zero).replace("%s", m.symbol).replace("%v", h(Math.abs(n), u(m.precision), m.thousand, m.decimal)) }; f.formatColumn = function (n, r, s, p, l, m) { if (!n) return []; var g = a(o(r) ? r : { symbol: r, precision: s, thousand: p, decimal: l, format: m }, f.settings.currency), y = c(g.format), b = y.pos.indexOf("%s") < y.pos.indexOf("%v"), v = 0; return i(n = i(n, function (n) { return t(n) ? f.formatColumn(n, g) : ((n = (0 < (n = d(n)) ? y.pos : 0 > n ? y.neg : y.zero).replace("%s", g.symbol).replace("%v", h(Math.abs(n), u(g.precision), g.thousand, g.decimal))).length > v && (v = n.length), n) }), function (n) { return e(n) && n.length < v ? b ? n.replace(g.symbol, g.symbol + Array(v - n.length + 1).join(" ")) : Array(v - n.length + 1).join(" ") + n : n }) }, "undefined" != typeof exports ? ("undefined" != typeof module && module.exports && (exports = module.exports = f), exports.accounting = f) : "function" == typeof define && define.amd ? define([], function () { return f }) : (f.noConflict = (s = n.accounting, function () { return n.accounting = s, f.noConflict = void 0, f }), n.accounting = f) }(this);


function setCustom() {

    //console.log('setCustom');
    if ($("[name='data[User][postcode]']").length) {
        $("[name='data[User][postcode]']").blur(function () {
            $input = $(this);
            if ($input.val() != "") {
                $.getJSON("https://api.postmon.com.br/v1/cep/" + $(this).val(), function (data, status) {
                    if (status == 'success') {
                        $("[name='data[User][address]']").val(data.logradouro);
                        $("[name='data[User][neighborhood]']").val(data.bairro);
                        $("[name='data[User][city]']").val(data.cidade);
                        $("[name='data[User][city_code_ibge]']").val(data.cidade_info.codigo_ibge);
                        $("[name='data[User][state]']").val(data.estado);
                        $("[name='data[User][state_code_ibge]']").val(data.estado_info.codigo_ibge);
                    }
                });
            }
        });
    }
    $('.cadastro-usuario .saving').click(function () {
        if ($('#UserCpf').attr('aria-invalid') == true) {
            return false;
        }
    });

    $("[name='data[User][cpf]']").blur(function () {
        var form = $(this).parents('form');
        if ($(this).val() != "") {
            $.ajax({
                'url': APP_ROOT + 'users/check_cpf/' + $(this).val(),
                'dataType': 'json',
                'success': function (data) {
                    if (data != 1) {
                        var validator = form.validate();
                        validator.showErrors({
                            "data[User][cpf]": "CPF inválido"
                        });
                        $('#UserCpf').attr('aria-invalid', 'true');
                        $('.saving').attr('disabled', 'true');
                        $('.error-user').show();
                    } else {
                        $('#UserCpf').attr('aria-invalid', 'false');
                        $('.saving').removeAttr('disabled');
                        $('.error-user').hide();
                    }
                }
            });
        }
    });

    /**
     *
     * @param val
     * @returns {string}
     * @constructor
     */
    var PhoneMask = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
        /**
         *
         * @type {{onKeyPress: spOptions.onKeyPress}}
         */
        PhoneMaskOptions = {
            onKeyPress: function (val, e, field, options) {
                field.mask(PhoneMask.apply({}, arguments), options);
            }
        };

    /**
     * Seta as mascaras de input
     * por [data-attr]
     */
    $('[data-phone-mask]').mask(PhoneMask, PhoneMaskOptions);
    $('[data-cpf-mask]').mask('000.000.000-00');
    $('[data-nascimento-mask]').mask('00/00/0000');
    $('[data-cep-mask]').mask('00000-000');
    $('.number').mask('99999999999999999999999999#');
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.money_wcenter').mask('000.000.000.000.000', { reverse: true });

    /**
     * Realiza a válidação dos formulários
     * mas, não o envio
     * @type {*}
     */
    var fd_validate = $('.fd-validate');
    fd_validate.each(function () {
        $(this).validate();
    });

    $('#UserSelfieSelfieForm').validate();

    $('#UserSelfieSelfieForm .btn-save').on('click', function () {
        if ($("#UserSelfieSelfieForm").valid()) {
            // do something here when the form is valid
            $('.btn-save').val('Enviando...');
        }
    });


    $('#ProjectFinancingValue').on('keyup', function () {
        var value = $('#ProjectFinancingValue').val().replace(",00", "");
        var value_minimum_investment = $('#ProjectFinancingValueMinimumInvestment').val().replace(",00", "");
        for (var i = 0; i < value.length; i++) {
            value = value.replace(".", "");
        }
        for (var i = 0; i < value_minimum_investment.length; i++) {
            value_minimum_investment = value_minimum_investment.replace(".", "");
        }
        var cota = 1000;
        if (value % cota === 0) {
            if (parseInt(value) >= parseInt(value_minimum_investment)) {
                $('.btn-step-1-next').removeAttr('disabled').val($('.btn-step-1-next').attr('rel')).removeAttr('style');
            } else {
                $('.btn-step-1-next').attr('disabled', 'disabled').val('Informe um valor mínimo de R$ ' + $('#ProjectFinancingValueMinimumInvestment').val()).attr('style', 'font-size: 11px; color; red');
            }
        } else {
            $('.btn-step-1-next').attr('disabled', 'disabled').val('Informe um valor múltiplo de R$ 1.000,00').attr('style', 'font-size: 11px; color; red');
        }
    });

    //btn-authy
    $('.btn-authy').click(function (e) {
        e.preventDefault();
        $('.btns-flex').hide();
        $('.content-form-validate').show();
        $('.btn-request-authy').show().closest('.col-xs-6').show();
        $('.btn-request-sms').closest('.col-xs-6').hide();
        $('.subtitle-sms').hide();
    });

    $('.btn-sms').click(function (e) {
        e.preventDefault();
        $('.btns-flex').hide();
        $('.content-form-validate').show();
        $('.btn-request-sms').show().closest('.col-xs-6').show();
        $('.btn-request-authy').closest('.col-xs-6').hide();
        $('.subtitle-sms').show();
    });

    $('.btn-request-cancel').click(function (e) {
        e.preventDefault();
        $('.content-form-validate').hide();
        $('.btns-flex').show();
    });

    $('.btn-cancel-verify').click(function (e) {
        e.preventDefault();
        $("[name*='data[User][authy_code]']").hide();
        $(".btn-authy-verify").hide();
        $("[name*='data[User][sms_code]']").hide();
        $(".btn-sms-verify").hide();
        $(this).hide();

        $('.content-form-validate').hide();
        $('.btns-flex').show();
        $(".btn-request-authy").hide().closest('.row').show();
        // $(".btn-authy").hide().closest('.row').show();
    });

    //btn-authy
    $('.btn-request-authy').click(function (e) {
        e.preventDefault();
        var btn = $(this);
        var $form = $('#UserStep4Form');
        var serializedData = $form.serialize();
        btn.prop('disabled', true).html('Processando...');

        // ajax
        request = $.ajax({
            url: APP_ROOT + 'project_financings/authy_request',
            type: "post",
            data: serializedData
        });

        request.done(function (response, textStatus, jqXHR) {
            // location.reload();
            response = $.parseJSON(response);
            if (response.type == 200) {
                $("[name*='data[User][authy_code]']").show().val('');
                $(".btn-authy-verify").show().closest('.col-xs-6').show();
                $("[name*='data[User][sms_code]']").hide().val('');
                $(".btn-sms-verify").hide().closest('.col-xs-6').hide();
                $('.btn-cancel-verify').show();
                $(".btn-request-authy").hide().closest('.row').hide();
            } else {
                btn.prop('disabled', false).html('Verificar com o APP AUTHY');
            }
        });

        request.fail(function (jqXHR, textStatus, errorThrown) {
            console.log(
                "The following error occured: " + textStatus, errorThrown);
        });

        request.always(function () {
            //
            btn.prop('disabled', false).html('Verificar com o APP AUTHY');
        });
    });

    //btn-authy-verify
    $('.btn-authy-verify').click(function (e) {
        e.preventDefault();
        var btn = $(this);
        var $form = $('#UserStep4Form');
        var serializedData = $form.serialize();
        btn.prop('disabled', true).html('Processando...');

        // ajax
        request = $.ajax({
            url: APP_ROOT + 'project_financings/authy_verify',
            type: "post",
            data: serializedData
        });

        request.done(function (response, textStatus, jqXHR) {
            // location.reload();
            console.log(response);
            response = $.parseJSON(response);
            if (response.type == 200) {
                $form.submit();
            } else {
                btn.prop('disabled', false).html('Validar código do APP AUTHY');
            }
        });

        request.fail(function (jqXHR, textStatus, errorThrown) {
            console.log(
                "The following error occured: " + textStatus, errorThrown);
        });

        request.always(function () {
            //
            btn.prop('disabled', false).html('Validar código do APP AUTHY');
        });
    });

    //btn-sms
    $('.btn-request-sms').click(function (e) {
        e.preventDefault();
        var btn = $(this);
        var $form = $('#UserStep4Form');
        var serializedData = $form.serialize();
        btn.prop('disabled', true).html('Processando...');

        // ajax
        request = $.ajax({
            url: APP_ROOT + 'project_financings/sms_request',
            type: "post",
            data: serializedData
        });

        request.done(function (response, textStatus, jqXHR) {
            // location.reload();
            response = $.parseJSON(response);
            if (response.type == 200) {

                $("[name*='data[User][authy_code]']").hide().val('');
                $(".btn-authy-verify").hide().closest('.col-xs-6').hide();
                $("[name*='data[User][sms_code]']").show().val('');
                $(".btn-sms-verify").show().closest('.col-xs-6').show();
                $('.btn-cancel-verify').show();
                $(".btn-request-authy").hide().closest('.row').hide();
            } else {
                btn.prop('disabled', false).html('Verificar com SMS');
            }

        });

        request.fail(function (jqXHR, textStatus, errorThrown) {
            console.log(
                "The following error occured: " + textStatus, errorThrown);
        });

        request.always(function () {
            //
            btn.prop('disabled', false).html('Verificar com SMS');
        });
    });

    //btn-sms-verify
    $('.btn-sms-verify').click(function (e) {
        e.preventDefault();
        var btn = $(this);
        var $form = $('#UserStep4Form');
        var serializedData = $form.serialize();
        btn.prop('disabled', true).html('Processando...');

        // ajax
        request = $.ajax({
            url: APP_ROOT + 'project_financings/sms_verify',
            type: "post",
            data: serializedData
        });

        request.done(function (response, textStatus, jqXHR) {
            // location.reload();
            console.log(response);
            response = $.parseJSON(response);
            if (response.type == 200) {
                $form.submit();
            } else {
                btn.prop('disabled', false).html('Validar código do APP AUTHY');
            }

        });

        request.fail(function (jqXHR, textStatus, errorThrown) {
            console.log(
                "The following error occured: " + textStatus, errorThrown);
        });

        request.always(function () {
            //
            btn.prop('disabled', false).html('Validar código do APP AUTHY');
        });
    });

    //$('.flagstrap').flagStrap();

    $('.flagstrap button').on('click', function () {
        var sibling = $(this).closest('.flagstrap').find('.dropdown-menu');

        if (!$(sibling).hasClass('active')) {
            sibling.addClass('active');
        } else {
            sibling.removeClass('active');
        }

        sibling.find('a').on('click', function () {
            sibling.removeClass('active');
            if ($(this).data('val').toString() === '55') {
                $('[data-phone-mask]').mask(PhoneMask, PhoneMaskOptions);
            } else {
                $(this).closest('.row').find('[data-phone-mask]').unmask();
            }

            sibling.find('.selected').removeClass('selected');
            $(this).addClass('selected');
        })

    });
}

function calculaMontanteProjetado(t, i, indice) {
    var capital = replaceAll($("#field-valorInvestimento").val(), ".", "");
    var valor = "R$ 0,00";
    t = (t / 12);
    console.log(t);
    if (capital.trim().length !== 0 && parseInt(capital) > 0) {
        var montante = capital * Math.pow(1 + i / 100, t);
        valor = accounting.formatMoney(montante, "R$ ", 2, ".", ",")
    }

    if (indice === "urbe") {
        $("#valor-calculado").html(valor);

    } else if (indice === "poupanca") {
        $("#valor-calculado-poupanca").html(valor);

    } else if (indice === "cdi") {
        $("#valor-calculado-cdi").html(valor);
    }
}


function replaceAll(val, find, replace) {
    var str = val;
    var pos = str.indexOf(find);
    while (pos > -1) {
        str = str.replace(find, replace);
        pos = str.indexOf(find);
    }
    return (str);
}

$(document).ready(function () {
    setCustom();

    if ($('.investment-simulator').length) {
        $("#field-valorInvestimento").keyup(function () {
            var cotaMinima = 1000;
            var valorReserva = $(this).val();

            if (typeof dataLayer != 'undefined') {
                dataLayer.push({ interaction: 'Calculadora', invest_intetion: valorReserva });
            }

            for (var i = 0; i < valorReserva.length; i++) {
                valorReserva = valorReserva.replace(".", "");
            }

            if ((valorReserva % cotaMinima) === 0) {
                // $("#msg-valor-minimo-multiplicador").removeClass("has-error");
                $(".fieldValorInvestimento").closest('.input').removeClass("has-error");
            } else {
                // $("#msg-valor-minimo-multiplicador").addClass("has-error");
                $(".fieldValorInvestimento").closest('.input').addClass("has-error");
            }
        });

        $("#slider-rentabilidade").freshslider({
            step: 1,
            unit: '%',
            min: 0,
            max: 50,
            value: rentabilidade,
            valueId: "slider-rentabilidade-id",
            onchange: function (low, high) {
                if (rentabilidade != parseInt(low)) {
                    rentabilidade = parseInt(low);

                    // var tempo = parseInt($("#slider-tempo .fscaret").html());
                    calculaMontanteProjetado(tempo, rentabilidade, "urbe");
                    calculaMontanteProjetado(tempo, rentabilidadePoupanca, "poupanca");
                    calculaMontanteProjetado(tempo, rentabilidadeCDI, "cdi");
                }
            }
        });

        $("#slider-tempo").freshslider({
            step: 1,
            min: 1,
            value: tempo,
            max: 360,
            valueId: "slider-tempo-id",
            onchange: function (low, high) {
                if (tempo != parseInt(low)) {
                    tempo = parseInt(low);
                    var rentabilidade = parseInt(replaceAll($("#slider-rentabilidade .fscaret").html(), "%", ""));
                    calculaMontanteProjetado(tempo, rentabilidade, "urbe");
                    calculaMontanteProjetado(tempo, rentabilidadePoupanca, "poupanca");
                    calculaMontanteProjetado(tempo, rentabilidadeCDI, "cdi");
                }
            }
        });

        $("#btn-calcular").click(function (e) {
            e.preventDefault();
            var capital = replaceAll($("#field-valorInvestimento").val(), ".", "");

            if (capital.trim().length !== 0 && parseInt(capital) > 0) {
                $("#msg-valor-minimo-multiplicador").removeClass("has-error");
                $("#field-valorInvestimento").removeClass("has-error");
            } else {
                $("#field-valorInvestimento").focus();
                $("#msg-valor-minimo-multiplicador").addClass("has-error");
                $("#field-valorInvestimento").addClass("has-error");
            }

            $("#resultado-calculo").hide();
            calculaMontanteProjetado(tempo, rentabilidade, "urbe");
            calculaMontanteProjetado(tempo, rentabilidadePoupanca, "poupanca");
            calculaMontanteProjetado(tempo, rentabilidadeCDI, "cdi");
            $("#resultado-calculo").fadeIn();
        });
        calculaMontanteProjetado(tempo, rentabilidade);
        calculaMontanteProjetado(tempo, rentabilidadePoupanca, "poupanca");
        calculaMontanteProjetado(tempo, rentabilidadeCDI, "cdi");
    }


    $('a[data-scroll]').click(function () {
        if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '')
            || location.hostname == this.hostname) {

            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        }
    });

    $('.btn-cancel-financing').click(function () {
        $('.form-cancel-financing').attr('action', $(this).data('url'));
    });

    $("[name*='cancel_status_id']").on('change', function () {
        var obj = $(this);
        $("[name*='cancel_reason']").attr('disabled', true);
        $("[name*='cancel_reason']").val('');
        obj.closest('.group').find("[name*='cancel_reason']").attr('disabled', false);
    });

});

$(window).on('load', function () {

    var ELEMENT = $('.project.reserve');
    if (ELEMENT.length > 0) {
        var FORM = ELEMENT.find('form');

        $('html, body').animate({
            scrollTop: FORM.offset().top - 250
        }, 1000);
    }

});


$(document).ready(function () {
    $('[data-component="related-articles"] .items, [data-component="know-urbe-lab"] .items').slick({
        dots: false,
        infinite: false,
        speed: 300,
        arrows: false,
        slidesToShow: 4,
        slidesToScroll: 4,
        responsive: [
            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 3,
                    dots: true
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    dots: true
                }
            },
            {
                breakpoint: 530,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    dots: true
                }
            }
        ]
    });
});


function fdSearch(parent) {
    console.log('FD Search Loaded');

    var select = $(parent);
    var target = $(select).data('target');

    $(select).find('input').on('keyup', function () {
        var termo = $(this).val().toLowerCase();

        $(select).find('ul li').each(function () {

            if ($(this).filter('[data-bank-name *= ' + termo + ']').length > 0 || termo.length < 1) {
                $(this).delay(50).fadeIn(50);
            } else {
                $(this).delay(50).fadeOut(50);
            }
        });
    });

    $(select).find('ul li').on('click', function () {
        $(select).find('span').html($(this).html());
        $(select).removeClass('active');

        $(select).find('ul li').removeClass('selected').delay(200).fadeIn(50);
        $(this).addClass('selected');

        var id = $(this).data('bank-id');
        $('#' + target).val(id);
        $(select).find('input').val('');
    });

    $(select).toggleClass('active');
}
