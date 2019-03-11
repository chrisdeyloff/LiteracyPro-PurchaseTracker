/**
This defines a Global object to serve loading external templates.
It handles multiple "Templates" (Or "Views") loading,
by operating on an array of JSON objects of type {path: "path to file", tag: "script's tag to attach to dom"}

This way-

you can load multiple templates, each with it's own tag so they can be referenced seperatly,

templates can be written in a much "cleaner" manner - as they are not wrapped by a "script" tag, IDE's will recognize the html.

A single event is raised after template loading has completed (loading & attach to DOM)

usage:

call "loadExtTemplates" on your array.

*/


var templatesLoader = (function ($, host) {

    /**
     * Name: rec_loadExtTemplates
     * Params:
     *   arr (JSON-Array): array of {path:"...", tag:".."}
     *   acc (string): accumulator
     *   
     * What do I Do ?
     *   Recursively traverse the JSON-Object array,
     *   for each object
     *    - try to "get" the template from path
     *    - if success
     *      - process a result (bound the result in <script> tag)
     *      - append result to accumulator
     *      - test if recursion end
     *         - true  - attach accumulator to "body" and trigger an event.
     *         - false - call recursively on smaller array.
     */
    var rec_loadExtTemplates = function (arr, acc) {
        var cur = $(arr).eq(0)[0];
        $.get(cur.path, function (result) { // On Success (done)
            result = "<script id=\"" + cur.tag + "\" type=\"text/x-kendo-template\">".concat(result).concat("</script>");
            acc += result;

            arr = $(arr).slice(1);
            if (arr.length) {
                rec_loadExtTemplates(arr, acc);
            } else { // we're done
                $("body").append(acc);
                $(host).trigger("TEMPLATES_LOADED");
            }
        })
            // Uncomment for debug:
            /*
            .done(function() {
                alert("SUCCESS");
            })*/
            .fail(function (err) {
                alert("AN ERROR OCCURED: \"" + cur.path + "\" returned with status of \"" + err.statusText + "\"");
            });
    };

    /**
     * Name: loadExtTemplates
     * Params:
     *   templatesArray (JSON-Array): array of JSON-Object each with format: {path:"<path to template", tag:"<unique tag for template>"}
     *   
     * What do I Do ?
   	 *    Loads external template from path and injects in to page DOM
     *    Template will be injected in a <script type="text/x-kendo-template"> tag, and selected id value.
     *    browser does not run scripts with unknown types - thus it will not run this injected script !
     */
    return {
        loadExtTemplates: function (templatesArray) {
            rec_loadExtTemplates(templatesArray, "");
        }
    };

})(jQuery, document);