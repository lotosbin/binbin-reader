var express = require('express');
var router = express.Router();
var service = require('../services/feedService.js');
/* GET users listing. */
router.get('/import', function(req, res, next) {
  service.getFeeds(function(data) {
    for (var i = 0; i < data.length; i++) {
      var outline = data[i];
      console.log(outline);
    }
  });
  res.send('respond with a resource');
});

module.exports = router;
