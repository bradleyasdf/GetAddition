function FindProxyForURL(url, host) {
  if (isInNet(host, '127.0.0.1', '255.0.0.255')
      || isInNet(dnsResolve(host), '127.0.0.1', '255.0.0.255')) {
    return 'DIRECT';
  }
  var regs = [
    '*.baidu.com'
  ];
  var match = false;
  for (var i = 0; i < regs.length; i++) {
    if (shExpMatch(host, regs[i])) {
      match = true;
      break;
    }
  }
  return match ? 'PROXY 24.148.73.79:8080' : 'DIRECT';
}