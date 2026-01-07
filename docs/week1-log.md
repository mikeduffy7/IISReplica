# Week 1 Progress Log
## Day 1
- [x] Read HTTP Made Really Easy
- [x] Read MDN HTTP Overview
- [x] Build HTTP client exercise
- [x] Answer architecture questions

- What are the 3 parts of an HTTP request? (Hint: request line, headers, body)
    request line, body, header
- What's in the request line? What information does it contain?
    method, uri, http version
- How does the server know when the request is complete? (This is critical for parsing!)
    when the headers end or the body ends (depends on method)
- What's the minimum valid HTTP/1.1 response? What must it contain?
    status line (http version, statuscode, status reason)
    blank link (CRLF)
    optional body
- Connection handling: What's the difference between HTTP/1.0 and HTTP/1.1 regarding connections? (Hint: Connection: close vs Keep-Alive)
    http/1.0 => closes connection after each request (new tcp connection each request)
    http/1.1 => default is keep-alive. content-length is important. connection will stay open until either side closes

- HTTP runs on TCP (no `http://` in socket connections)
- Request format: request line + headers + blank line + optional body
- Response format: status line + headers + blank line + body
- Headers end at `\r\n\r\n` (blank line)
- Must handle reading in chunks/loops


## Day 2
- [ ] Complete reading list
- [ ] Design TCP listener architecture
