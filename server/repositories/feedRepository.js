var r = {};
r.connect = function(callback) {
  var MongoClient = require('mongodb').MongoClient,
    assert = require('assert');

  // Connection URL
  var url = 'mongodb://localhost:27017/reader';
  // Use connect method to connect to the Server
  MongoClient.connect(url, function(err, db) {
    if (callback) callback(err, db);
    else
      db.close();
  });
};
r.add = function(outline, callback) {
  var insertDocuments = function(db, callback) {
    // Get the documents collection
    var collection = db.collection('reader');
    // Insert some documents
    collection.insert([outline], function(err, result) {
      if (callback)
        callback(result);
    });
  }
};
module.exports = r;
