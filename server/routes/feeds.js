var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/import', function(req, res, next) {
  var OpmlParser  = require('opmlparser');
  var opmlparser = new OpmlParser();
  var request = require('request');
  var req = request('http://localhost:3333/opml/opml.xml');
  req.on('error',function(error){
    console.log('error:'+JSON.stringify(error));
  });
  opmlparser.on('error',function(error){
    console.log('error:'+JSON.stringify(error));
  })
  opmlparser.on('readable',function(){
    var stream = this;
    var meta = this.meta;
    console.log('meta:'+JSON.stringify(meta));
    var outline;
    while(outline = stream.read()){
      console.log(outline);
    }
  });
  req.on('response',function(res){
    console.log('response:'+res.statusCode);
    var stream = this;
    if(res.statusCode != 200){
      return this.emit('error',new Error('Bad status code'));
    }
    stream.pipe(opmlparser);
  });

  res.send('respond with a resource');
});

module.exports = router;
