use pcap_parser::*;
use pcap_parser::traits::PcapReaderIterator;
use std::fs::File;

fn main()
{
    let path = "test.pcap";
    let file = File::open(path).unwrap();
    let mut num_blocks = 0;
    let mut reader = PcapNGReader::new(65536, file).expect("PcapNGReader");
    loop {
        match reader.next() {
            Ok((offset, _block)) => {
                println!("got new block");
                num_blocks += 1;
                reader.consume(offset);
            },
            Err(PcapError::Eof) => break,
            Err(PcapError::Incomplete(_)) => {
                reader.refill().unwrap();
            },
            Err(e) => panic!("error while reading: {:?}", e),
        }
    }
    println!("num_blocks: {}", num_blocks);
}