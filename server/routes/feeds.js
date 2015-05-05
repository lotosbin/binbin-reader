var express = require('express');
var router = express.Router();

/* GET users listing. */
router.get('/import', function(req, res, next) {
  var opmlparser = require('opmlparser');
  var request = require('request');
  var req = request('./opml.xml');
  req.on('error',function(error){
    console.log(JSON.stringify(error));
  });
  req.on('response',function(res){
    var stream = this;
    if(res.statusCode != 200){
      return this.emit('error',new Error('Bad status code'))''
    }
    stream.piple(opmlparser);
  });
  opmlparser.on('error',function(error){
    console.log(JSON.stringify(error));
  })
  opmlparser.on('readable',function(){
    var stream = this;
    var meta = this.meta;
    var outline;
    while(outline = stream.read()){
      console.log(outline);
    }
  })
  res.send('respond with a resource');
});

module.exports = router;
