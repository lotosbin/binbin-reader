var express = require('express');
var router = express.Router();
var feed = require("feed-read");
/* GET home page. */
router.get('/', function(req, res, next) {
  feed("http://craphound.com/?feed=rss2", function(err, articles) {
  if (err) throw err;
    // Each article has the following properties:
    //
    //   * "title"     - The article title (String).
    //   * "author"    - The author's name (String).
    //   * "link"      - The original article link (String).
    //   * "content"   - The HTML content of the article (String).
    //   * "published" - The date that the article was published (Date).
    //   * "feed"      - {name, source, link}
    //
    console.log(JSON.stringify(articles));
    res.render('index',{title:'Express',items:articles})
  });
});

module.exports = router;
