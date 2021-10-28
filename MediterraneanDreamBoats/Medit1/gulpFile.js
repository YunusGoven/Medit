/// <binding AfterBuild='clean, mincss, minimage, minjs, minjs1, minjs2, minjs3' />
var gulp = require("gulp"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    del = require("del"),
    imagemin = require("gulp-imagemin");

var webrootFolder = "wwwroot";
var paths = { webroot: "./" + webrootFolder + "/" };

paths.js = paths.webroot + "js/createCruise.js";
paths.js1 = paths.webroot + "js/createReservation.js";
paths.js2 = paths.webroot + "js/cruisesFilter.js";
paths.js3 = paths.webroot + "js/editReservation.js";
paths.css = paths.webroot + "css/**/*.css";
paths.mylib = paths.webroot + "mylib";
paths.image = paths.webroot + "images/**/*.*";

//---//

gulp.task("clean", () => del.sync(paths.mylib + "/"));

gulp.task("minjs", () => gulp.src(paths.js).pipe(concat("createCruise.min.js")).pipe(uglify()).pipe(gulp.dest(paths.mylib)));
gulp.task("minjs1", () => gulp.src(paths.js1).pipe(concat("createReservation.min.js")).pipe(uglify()).pipe(gulp.dest(paths.mylib)));
gulp.task("minjs2", () => gulp.src(paths.js2).pipe(concat("cruisesFilter.min.js")).pipe(uglify()).pipe(gulp.dest(paths.mylib)));
gulp.task("minjs3", () => gulp.src(paths.js3).pipe(concat("editReservation.min.js")).pipe(uglify()).pipe(gulp.dest(paths.mylib)));

gulp.task("mincss", () => gulp.src(paths.css).pipe(concat("style.min.css")).pipe(cssmin()).pipe(gulp.dest(paths.mylib)));

gulp.task("minimage", () => gulp.src(paths.image).pipe(imagemin()).pipe(gulp.dest(paths.mylib)));