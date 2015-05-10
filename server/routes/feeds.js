var express = require('express');
var router = express.Router();
var service = require('../services/feedService');
/* GET users listing. */
router.get('/import', function(req, res, next) {
  service.getFeeds(function(data) {
    for (var i = 0; i < data.length; i++) {
      var outline = data[i];
      console.log(outline);
      var repo = require('../repositories/feedRepository');
      repo.add(outline);
    }
  });
  res.send('respond with a resource');
});
router.get('/index', function(req, res, next) {
  var outlines = [];
  res.send(outlines);
})
module.exports = router;
