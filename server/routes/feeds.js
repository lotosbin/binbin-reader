var express = require('express');
var router = express.Router();
var service = require('../services/feedService');
/* GET users listing. */
router.get('/import', function(req, res, next) {
  service.getFeeds(function(data) {
    var repo = require('../repositories/feedRepository');
    repo.add(data);
  });
  res.send('respond with a resource');
});
router.get('/index', function(req, res, next) {
  var outlines = [];
  res.send(outlines);
})
module.exports = router;
